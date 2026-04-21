using Controllers;
using Xunit;

namespace Tests
{
    public class CustomHashTableTests
    {
        [Fact]
        public void AddOrUpdate_ShouldStoreAndRetrieveValue()
        {
            // Arrange
            var table = new CustomHashTable<string, int>();

            // Act
            table.AddOrUpdate("apple", 10);
            bool found = table.TryGetValue("apple", out int value);

            // Assert
            Assert.True(found);
            Assert.Equal(10, value);
        }

        [Fact]
        public void AddOrUpdate_ShouldUpdateExistingKey()
        {
            // Arrange
            var table = new CustomHashTable<string, string>();

            // Act
            table.AddOrUpdate("user_1", "old_value");
            table.AddOrUpdate("user_1", "new_value");
            table.TryGetValue("user_1", out string value);

            // Assert
            Assert.Equal("new_value", value);
        }

        [Fact]
        public void TryGetValue_ShouldReturnFalse_WhenKeyDoesNotExist()
        {
            // Arrange
            var table = new CustomHashTable<int, string>();

            // Act
            bool found = table.TryGetValue(999, out string value);

            // Assert
            Assert.False(found);
            Assert.Null(value);
        }

        [Fact]
        public void GetAll_ShouldReturnAllInsertedElements()
        {
            // Arrange
            var table = new CustomHashTable<string, int>();
            table.AddOrUpdate("a", 1);
            table.AddOrUpdate("b", 2);
            table.AddOrUpdate("c", 3);

            // Act
            var all = table.GetAll();

            // Assert
            Assert.Equal(3, all.Count);
        }
    }
}