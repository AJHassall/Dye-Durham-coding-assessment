using System.Collections.Generic;
using System.IO;
using Moq;
using name_sorter.Data;
using NameSortingUtility.Services;
using NUnit.Framework;

namespace name_sorter_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private const string FileName = "TestFile1.txt"; // Replace with your actual file name

        private string GetTestFilePath()
        {
            // Get the project directory path (assuming the test project structure)
            string projectPath = Path.GetDirectoryName(TestContext.CurrentContext.WorkDirectory);

            // Combine project path with the test file path
            return Path.Combine(projectPath, "net8.0", "TestFiles", FileName);
        }

        [Test]
        public void GetValuesFromFile_ValidPath_ReturnsListOfT()
        {
            // Arrange
            string filePath = GetTestFilePath();
            var streamReader = new StreamReader(filePath);

            // Act
            var service = new FileImportService<Name>(streamReader);
            var values = service.GetValuesFromFile();

            // Assert
            Assert.NotNull(values);
            Assert.That(values.Count, Is.EqualTo(11));
            Assert.IsInstanceOf<List<Name>>(values);
        }

        [Test]
        public void GetValuesFromFile_EmptyFile_ReturnsEmptyList()
        {
            // Arrange
            var mockReader = new Mock<StreamReader>(GetTestFilePath());
            mockReader.Setup(reader => reader.ReadLine()).Returns((string)null); // Simulate empty file

            // Act
            var service = new FileImportService<Name>(mockReader.Object);
            var values = service.GetValuesFromFile();

            // Assert
            Assert.NotNull(values);
            Assert.IsEmpty(values);
        }

        [Test]
        public void GetValuesFromFile_InvalidPath_ThrowsFileNotFoundException()
        {
            // Arrange
            string invalidPath = "NonExistentFile.txt";

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => new FileImportService<Name>(new StreamReader(invalidPath)));
        }

    }
}
