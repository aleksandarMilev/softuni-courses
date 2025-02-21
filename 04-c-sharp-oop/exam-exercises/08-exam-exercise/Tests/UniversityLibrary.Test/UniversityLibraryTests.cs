using NUnit.Framework;

namespace UniversityLibrary.Test
{
    [TestFixture]
    public class UniversityLibraryTests
    {
        private UniversityLibrary library;
        private TextBook textBook;

        [SetUp]
        public void Setup()
        {
            library = new();
            textBook = new("1984", "George Orwell", "Dystopia");
        }

        [Test]
        public void ConstructorShouldInitializeInnerCollection()
        {
            Assert.IsNotNull(library.Catalogue);
        }

        [Test]
        public void AddTextBookToLibraryShouldSetCorrectBookInventoryNumber()
        {
            _ = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, textBook.InventoryNumber);
        }

        [Test]
        public void AddTextBookToLibraryShouldAddTheGivenBook()
        {
            _ = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(textBook, library.Catalogue[0]);
        }

        [Test]
        public void AddTextBookToLibraryShouldReturnBookToStringMethod()
        {
            string actualResult = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(textBook.ToString(), actualResult);
        }

        [Test]
        public void LoanTextBookShouldReturnTheCorrectMessageIfTheBookIsNotReturnedYet()
        {
            textBook.Holder = "Alex";
            _ = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual("Alex still hasn't returned 1984!", library.LoanTextBook(1, "Alex"));
        }

        [Test]
        public void LoanTextBookShouldSetTheStudentNameToTheBookHolderSetterIfTheBookIsAvailableInTheLibrary()
        {
            _ = library.AddTextBookToLibrary(textBook);
            _ = library.LoanTextBook(1, "Alex");

            Assert.AreEqual("Alex", textBook.Holder);
        }

        [Test]
        public void LoanTextBookShouldReturnTheCorrectMessageIfTheBookIsAvailableInTheLibrary()
        {
            _ = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual("1984 loaned to Alex.", library.LoanTextBook(1, "Alex"));
        }

        [Test]
        public void ReturnTextBookShouldSetTheBookHolderToEmptyString()
        {
            _ = library.AddTextBookToLibrary(textBook);
            _ = library.LoanTextBook(1, "Alex");
            _ = library.ReturnTextBook(1);

            Assert.IsEmpty(textBook.Holder);
        }

        [Test]
        public void ReturnTextBookShouldReturnTheCorrectMessage()
        {
            _ = library.AddTextBookToLibrary(textBook);
            _ = library.LoanTextBook(1, "Alex");

            Assert.AreEqual("1984 is returned to the library.", library.ReturnTextBook(1));
        }
    }
}