namespace Webapp.dal
{
    public class BodyDataDAL
    {
        public async Task<String> getBodyDatasAsync()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://192.168.44.127:7272/BodyData");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                return textResult;
            }
        }
    }
}
