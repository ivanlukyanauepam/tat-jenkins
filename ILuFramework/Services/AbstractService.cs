namespace ILuFramework.Services
{
    using ILuFramework.Pages;

    public class AbstractService
    {
        protected AbstractPage page;
        protected AbstractService()
        {

        }

        protected virtual void OpenPage()
        {

        }

        protected virtual void ClosePage()
        {
            page.Close();
        }
    }
}
