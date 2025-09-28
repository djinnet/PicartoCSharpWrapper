using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace PicartoCSharpWrapper.Tests
{
    public class BasicUnitTest
    {
        private PicartoReadOnlyClient client;
        private Mock<HttpMessageHandler> handlerMock;


        [SetUp]
        public void Setup()
        {
            handlerMock = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(handlerMock.Object);

            // Use reflection to set the httpClient in BasePicartoClient
            client = (PicartoReadOnlyClient)Activator.CreateInstance(
                typeof(PicartoReadOnlyClient),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null,
                new object[] { null },
                null
            );
            typeof(PicartoReadOnlyClient)
                .GetField("httpClient", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .SetValue(client, httpClient);
        }

        [Test]
        public async Task CategoriesAsync_ReturnsList()
        {
            var categories = new List<Categories> { new Categories { Id = 1, Name = "Art" } };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(categories))
            };

            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var result = await client.CategoriesAsync();
            Assert.That(result, Is.InstanceOf<List<Categories>>());
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task CategoriesAsync_Basic_ReturnsList()
        {
            var result = await client.CategoriesAsync();
            Assert.That(result, Is.InstanceOf<List<Categories>>());
        }

        [Test]
        public async Task ShowChannelByNameAsync_ThrowsOnNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await client.ShowChannelByNameAsync(null);
            });
        }

        [Test]
        public async Task ShowChannelByIdAsync_ThrowsOnNull()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await client.ShowChannelByIdAsync(0);
            });
        }

        [Test]
        public void GetPopOutChat_ReturnsUrl()
        {
            var url = client.GetPopOutChat("testuser");
            Assert.That(url.Contains("testuser"), Is.True);
        }

        [Test]
        public async Task GetUserAvatarAsync_ReturnsString()
        {
            var avatar = await client.GetUserAvatarAsync("testuser");
            Assert.That(avatar, Is.InstanceOf<string>());
        }

        [Test]
        public async Task GetChannelLanguagesAsync_ReturnsList()
        {
            var languages = await client.GetChannelLanguagesAsync("testuser");
            Assert.That(languages, Is.InstanceOf<List<Language>>());
        }

        [Test]
        public async Task GetThumbnailAsync_ReturnsThumbnails()
        {
            var thumbnail = await client.GetThumbnailAsync("testuser");
            Assert.That(thumbnail, Is.InstanceOf<Thumbnails>());
        }
    }
}
