using Xunit;

namespace WebDriverTesting
{
    public class BlogPostTests
    {
        private Comment ExampleComment = new Comment
        {
            Name = "Selenium",
            Email = "some_mail@whatever.com",
            Text = "hey! świetny tekst :)"
        };

        [Fact]
        public void When_user_is_not_logged_in_can_add_comment_on_second_note()
        {
            MainPage.GoTo();
            MainPage.AssertNotLoggedIn();
            MainPage.ShowNextPage();
            MainPage.LeaveComment(ExampleComment);
            MainPage.AssertCommentExist(ExampleComment);
        }
    }
}
