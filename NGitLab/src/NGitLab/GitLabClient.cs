using Autofac;
using NGitLab.Impl;
using NGitLab.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NGitLab
{
    /// <summary>
    /// Class that implements <see cref="IGitLabClient"/> that can be used to communicate with a GitLab Server.
    /// </summary>
    public class GitLabClient : IGitLabClient
    {
        public IUserClient Users { get; private set; }

        public IProjectClient Projects { get; private set; }

        public IIssueClient Issues { get; private set; }

        public INamespaceClient Groups { get; private set; }

        public ILabelClient Labels { get; private set; }

        public IMembersClient Members { get; private set; }

        private static IContainer _container;

        public GitLabClient(string hostUrl, string privateToken = "")
        {
            var builder = new ContainerBuilder();

            var client = new HttpClient { BaseAddress = new Uri(hostUrl) };
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", privateToken);

            builder.Register(c => client);

            builder.Register(c => new HttpRequestor()
            {
                Client = c.Resolve<HttpClient>(),
                HostUrl = hostUrl
            });

            builder.RegisterType<UserClient>().As<IUserClient>();
            builder.RegisterType<ProjectClient>().As<IProjectClient>();
            builder.RegisterType<IssueClient>().As<IIssueClient>();
            builder.RegisterType<NamespaceClient>().As<INamespaceClient>();
            builder.RegisterType<LabelClient>().As<ILabelClient>();
            builder.RegisterType<MembersClient>().As<IMembersClient>();

            builder.RegisterType<GitLabClient>().As<IGitLabClient>();

            _container = builder.Build();

            Users = _container.Resolve<IUserClient>();
            Projects = _container.Resolve<IProjectClient>();
            Issues = _container.Resolve<IIssueClient>();
            Groups = _container.Resolve<INamespaceClient>();
            Labels = _container.Resolve<ILabelClient>();
            Members = _container.Resolve<IMembersClient>();
        }

        internal GitLabClient(string hostUrl, string privateToken, HttpClient client)
        {
            var builder = new ContainerBuilder();

            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", privateToken);
            builder.Register(c => client);

            builder.Register(c => new HttpRequestor
            {
                Client = c.Resolve<HttpClient>(),
                HostUrl = hostUrl
            });

            builder.RegisterType<UserClient>().As<IUserClient>();
            builder.RegisterType<ProjectClient>().As<IProjectClient>();
            builder.RegisterType<IssueClient>().As<IIssueClient>();
            builder.RegisterType<NamespaceClient>().As<INamespaceClient>();
            builder.RegisterType<LabelClient>().As<ILabelClient>();
            builder.RegisterType<MembersClient>().As<IMembersClient>();

            builder.RegisterType<GitLabClient>().As<IGitLabClient>();

            _container = builder.Build();

            Users = _container.Resolve<IUserClient>();
            Projects = _container.Resolve<IProjectClient>();
            Issues = _container.Resolve<IIssueClient>();
            Groups = _container.Resolve<INamespaceClient>();
            Labels = _container.Resolve<ILabelClient>();
            Members = _container.Resolve<IMembersClient>();
        }

        /// <summary>
        /// Login to the GitLab host.
        /// </summary>
        /// <param name="username">GitLab Username.</param>
        /// <param name="password">GitLab Password.</param>
        /// <returns><see cref="Session"/> object with the current session information.</returns>
        public async Task<Session> LoginAsync(string username, string password)
        {
            var httpRequestor = _container.Resolve<HttpRequestor>();
            var session = await httpRequestor.Post<Session>($"/session?login={username}&password={password}");

            var client = _container.Resolve<HttpClient>();
            if (client.DefaultRequestHeaders.Contains("PRIVATE-TOKEN"))
            {
                client.DefaultRequestHeaders.Remove("PRIVATE-TOKEN");
            }
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", session.PrivateToken);

            return session;
        }

        public IRepositoryClient GetRepository(int projectId) => new RepositoryClient(_container.Resolve<HttpRequestor>(), projectId);

        public IMergeRequestClient GetMergeRequest(int projectId) => new MergeRequestClient(_container.Resolve<HttpRequestor>(), projectId);
    }
}