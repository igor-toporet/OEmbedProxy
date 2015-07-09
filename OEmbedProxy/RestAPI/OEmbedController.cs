using System;
using System.Web.Http;

namespace OEmbedProxy.RestAPI
{
    [RoutePrefix("")]
    public class OEmbedController : ApiController
    {
        // embed?url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DDK4x-8JNmxI

        [HttpGet]
        [Route("embed")]
        public IHttpActionResult GetOEmbed([FromUri] string url)
        {
            var result = new OEmbed
            {
                ProviderName = "blah",
                ProviderUrl = new Uri(url)
            };

            return Ok(result);
        }

        [HttpGet]
        [Route("providers")]
        public IHttpActionResult GetProviders()
        {
            var result = new[]
            {
                new OEmbeddedContentProvider
                {
                    ProviderName = "Youtube",
                    ProviderUrl = "youtube.com"
                },
                new OEmbeddedContentProvider
                {
                    ProviderName = "Vimeo",
                    ProviderUrl = "vimeo.com"
                }
            };

            return Ok(result);
        }
    }
}