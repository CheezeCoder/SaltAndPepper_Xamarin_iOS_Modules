using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using Contacts;
using Foundation;

namespace ContactPicker 
{

	/// <summary>
	/// An extra class to help give us some missing CNLabelPhoneNumberKeys such as home.
	/// </summary>
	public static class CNLabelPhoneNumberExtd
	{
		public static NSString Home = new NSString("_$!<Home>!$_");
	}

	/// <summary>
	/// A class to help seed data into our fake database repository.  We use this class to iniate both how certain table views will look as well as their
	/// state date.
	/// </summary>
	public class FakeRepositorySeederHelper
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Access state for the users contact access grant.
		/// </summary>
		private readonly bool access;
		/// <summary>
		/// The Contacts store of the user if they have granted access.
		/// </summary>
		private readonly CNContactStore store;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="ContactPicker.FakeRepositorySeederHelper"/> class.
		/// </summary>
		public FakeRepositorySeederHelper (bool access)
		{
			this.access = access;
			if (access) {
				store = new CNContactStore ();
			}
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================

		/// <summary>
		/// Creates a list of all contacts in the users Contacts book.
		/// </summary>
		/// <returns>The fake object list context.</returns>
		public List<CNContact> initFakeObjectListContext()
		{
			var ContactList = new List<CNContact> ();
			
			if (access) {

				var predicate = CNContact.GetPredicateForContactsInContainer (store.DefaultContainerIdentifier);
				var keys = new NSString[] { CNContactKey.GivenName, CNContactKey.FamilyName, CNContactKey.PhoneNumbers};

				Foundation.NSError error;
				ContactList = store.GetUnifiedContacts (predicate, keys, out error).ToList ();
			}

			return ContactList;
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================

	}


	///<summary>
	/// The fake repository for our Contact List.  
	///</summary>
	public class FakeObjectListRepository
	{
		/// <summary>
		/// A custom class to act as a container for the attributed text to be passed to the Table Cells
		/// </summary>
		public class ContactItem{
			/// <summary>
			/// Private property of a contacts full name.
			/// </summary>
			private readonly NSMutableAttributedString fullname;
			/// <summary>
			/// Private property of a contacts number with prefix.
			/// </summary>
			private readonly NSMutableAttributedString number;

			/// <summary>
			/// Initializes a new instance of the <see cref="ContactPicker.FakeObjectListRepository.ContactItem"/> class.
			/// </summary>
			/// <param name="fn">Fn.</param>
			/// <param name="n">N.</param>
			public ContactItem (NSMutableAttributedString fn, NSMutableAttributedString n)
			{
				fullname 	= fn;
				number 		= n;
			}

			/// <summary>
			/// Accessor for the attributed text fullname.
			/// </summary>
			/// <value>The full name.</value>
			public NSMutableAttributedString FullName {get{ return fullname;} private set{ }}
			/// <summary>
			/// Accessor for the attributed text number.
			/// </summary>
			/// <value>The phone number.</value>
			public NSMutableAttributedString PhoneNumber {get{ return number;} private set{ }}
		}
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Fake context for our contact item list.
		/// </summary>
		private readonly List<ContactItem> simulatedDBContext; 
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================

		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.FakeObjectListRepository"/> class.
		/// </summary>
		public FakeObjectListRepository (List<CNContact> fakeContext)
		{
			simulatedDBContext = parseContacts (fakeContext);
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Returns all of the objects in our fake context.
		/// </summary>
		public List<ContactItem> All()
		{
			return simulatedDBContext;	
		}
			
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		/// <summary>
		/// This method parses the contacts and builds two strings to store in our ContactItem class. We get the names of the contact
		/// and then loop through their numbers and add an entry for each number.  Because we want to style the output a bit 
		/// we use NSMutableAttributedText classes to help style our text to show up the way we want it to. We also check for
		/// each number what type of number it is and assign a prefix to it so that we mimick the way the iOS contacts filter works
		/// on the default iOS messages app.
		/// </summary>
		/// <returns>The contacts.</returns>
		/// <param name="contacts">Contacts.</param>
		private List<ContactItem> parseContacts(List<CNContact> contacts)
		{
			var ContactItemList = new List<ContactItem> ();
			foreach (CNContact contact in contacts) {
				var fName 		= contact.GivenName;
				var lName 		= contact.FamilyName;
				var fullName 		= "";
				var number 		= "";
				var phoneNumbers 	= contact.PhoneNumbers.ToList();

				if (String.IsNullOrEmpty (fName)) {
					fName = "";
				}
				if (String.IsNullOrEmpty (lName)) {
					lName = "";
				}

				fullName = fName + " " + lName;


				foreach (CNLabeledValue<CNPhoneNumber> phoneNumber in phoneNumbers) {
					int range = 0;
					if (phoneNumber.Label == CNLabelPhoneNumberKey.iPhone) {
						number = "iPhone: " + (phoneNumber.Value as CNPhoneNumber).StringValue;
						range = 7;
					} else if (phoneNumber.Label == CNLabelPhoneNumberKey.Mobile) {
						number = "Mobile: " + (phoneNumber.Value as CNPhoneNumber).StringValue;
						range = 7;
					} else if (phoneNumber.Label == CNLabelPhoneNumberKey.Main) {
						number = "Main: " + (phoneNumber.Value as CNPhoneNumber).StringValue;
						range = 5;
					} else if (phoneNumber.Label == CNLabelPhoneNumberExtd.Home) {
						number = "Home: " + (phoneNumber.Value as CNPhoneNumber).StringValue;
						range = 5;
					} else {
						break;
					}

					var attributedStringFullName 	= new NSMutableAttributedString (fullName);
					var attributedStringPhoneNumber = new NSMutableAttributedString (number);



					attributedStringFullName.SetAttributes (new UIStringAttributes () {
						Font = UIFont.BoldSystemFontOfSize(UIFont.LabelFontSize)
					}, new NSRange(0, attributedStringFullName.Length));

					attributedStringPhoneNumber.SetAttributes(new UIStringAttributes () {
						Font = UIFont.BoldSystemFontOfSize(UIFont.SystemFontSize)
					}.Dictionary, new NSRange(0,range));

					var contactItem = new ContactItem (attributedStringFullName, attributedStringPhoneNumber);
					ContactItemList.Add (contactItem);
				}
			}
			return ContactItemList;

		}
	}



}