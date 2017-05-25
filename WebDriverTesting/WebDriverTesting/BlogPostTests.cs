using System;
using Xunit;

namespace WebDriverTesting
{
    public class BlogPostTests : IDisposable
    {
        private Comment ExampleComment = new Comment
        {
            Author = Guid.NewGuid().ToString(),
            Email = "some_mail@whatever.com",
            Text = Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()
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

        public void Dispose()
        {
            WebBrowser.Driver.Quit();
        }
    }
}
