using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NGitLab.Dotnet.Tests.Infrastructure
{
    public class FakeResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> fakeGetResponses = new Dictionary<Uri, HttpResponseMessage>();
        private readonly Dictionary<Uri, HttpResponseMessage> fakePostResponses = new Dictionary<Uri, HttpResponseMessage>();
        private readonly Dictionary<Uri, HttpResponseMessage> fakePutResponses = new Dictionary<Uri, HttpResponseMessage>();
        private readonly Dictionary<Uri, HttpResponseMessage> fakeDeleteResponses = new Dictionary<Uri, HttpResponseMessage>();

        public void AddFakeGetResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            fakeGetResponses.Add(uri, responseMessage);
        }

        public void AddFakePostResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            fakePostResponses.Add(uri, responseMessage);
        }

        public void AddFakePutResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            fakePutResponses.Add(uri, responseMessage);
        }

        public void AddFakeDeleteResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            fakeDeleteResponses.Add(uri, responseMessage);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Get)
            {
                if (fakeGetResponses.ContainsKey(request.RequestUri))
                {
                    return Task.FromResult(fakeGetResponses[request.RequestUri]);
                }
            }
            else if (request.Method == HttpMethod.Post)
            {
                if (fakePostResponses.ContainsKey(request.RequestUri))
                {
                    return Task.FromResult(fakePostResponses[request.RequestUri]);
                }
            }
            else if (request.Method == HttpMethod.Put)
            {
                if (fakePutResponses.ContainsKey(request.RequestUri))
                {
                    return Task.FromResult(fakePutResponses[request.RequestUri]);
                }
            }
            else if (request.Method == HttpMethod.Delete)
            {
                if (fakeDeleteResponses.ContainsKey(request.RequestUri))
                {
                    return Task.FromResult(fakeDeleteResponses[request.RequestUri]);
                }
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                RequestMessage = request
            });
        }
    }
}
