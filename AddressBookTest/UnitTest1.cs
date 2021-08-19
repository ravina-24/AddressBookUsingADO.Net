using AddressBookUsingADO.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBook addressBook = new AddressBook();
        AddressBookModel model = new AddressBookModel();

        [TestMethod]
        public void AddingContactShouldReturnTrue()
        {
            model.FirstName = "Meghan";
            model.LastName = "markel";
            model.Address = "361 Randall Mill ";
            model.City = "Vegas";
            model.State = "Texas";
            model.ZipCode = "908384";
            model.PhoneNumber = "6725114457";
            model.EmailId = "MeghanMarkel97@gmail.com";

            var result = addressBook.AddContacts(model);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdatingContactShouldReturnTrue()
        {
            model.FirstName = "Meghan";
            model.LastName = "Auston";
            model.Address = "6 North Kirkland Rd";
            model.City = "New york";
            model.State = "New york";
            model.ZipCode = "668899";
            model.PhoneNumber = "6789025352";
            model.EmailId = "MeghanA23@xyz.com";

            var result = addressBook.EditContact(model);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DelectingContactShouldReturnTrue()
        {
            model.FirstName = "Joe";
            model.LastName = "pane";
            model.Address = "9469 Wild Rose Ave,";
            model.City = "Spokane";
            model.State = "Washington";
            model.ZipCode = "908894";
            model.PhoneNumber = "9087654457";
            model.EmailId = "JoePane67@gmail.com";

            var result = addressBook.DeleteContact(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenCityOrStateShouldReturnDataIfFound()
        {
            var result = addressBook.DisplayByCityOrState(model);
            Assert.IsNotNull(result);
        }
    }
}
   
