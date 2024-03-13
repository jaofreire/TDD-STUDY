using Domain.Models;


namespace TDD
{
    public class TasksTest
    {
        [Fact]
        public void SucessCreateTask()
        {
            //Arrange
            var title = "Title";
            var description = "Description";
            var experateDate = DateTime.Now;
            var priority = 1;
            var tickets = new List<string>() { "Test1", "Test2" };

            //Act
            var newTask = new TaskModel(title, description, experateDate, priority, tickets);
           
            //Assert
            Assert.Equal(title, newTask.Title);
            Assert.Equal(description, newTask.Description);
        }
    }
}