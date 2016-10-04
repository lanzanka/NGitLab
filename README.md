![Icon](https://raw.githubusercontent.com/Franklin89/NGitLab/develop/docs/img/package_icon.png)

# NGitLab

![License](https://img.shields.io/github/license/franklin89/NGitLab.svg)
[![Gitter](https://badges.gitter.im/JoinChat.svg)](https://gitter.im/ML-Software/NGitLab?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Nuget Version](https://img.shields.io/nuget/v/NGitLab.svg)](https://www.nuget.org/packages/NGitLab/)
[![Nuget Version](https://img.shields.io/nuget/vpre/NGitLab.svg)](https://www.nuget.org/packages/NGitLab/)

## Build Status

|Latest|Develop|Master|
|:--:|:--:|:--:|
|[![Build status](https://ci.appveyor.com/api/projects/status/4sufsyhxh9m7ga6g?svg=true)](https://ci.appveyor.com/project/Franklin89/ngitlab)|[![Build status](https://ci.appveyor.com/api/projects/status/4sufsyhxh9m7ga6g/branch/develop?svg=true)](https://ci.appveyor.com/project/Franklin89/ngitlab/branch/develop)|[![Build status](https://ci.appveyor.com/api/projects/status/4sufsyhxh9m7ga6g/branch/master?svg=true)](https://ci.appveyor.com/project/Franklin89/ngitlab/branch/master)|

## Coverage
|Develop|Master|
|:--:|:--:|
|[![Coverage Status](https://coveralls.io/repos/github/Franklin89/NGitLab/badge.svg?branch=develop)](https://coveralls.io/github/Franklin89/NGitLab?branch=develop)|[![Coverage Status](https://coveralls.io/repos/github/Franklin89/NGitLab/badge.svg?branch=master)](https://coveralls.io/github/Franklin89/NGitLab?branch=master)|

## What is NGitLab?

*NGitLab* is a .NET REST client implementation of GitLab API.

## Roadmap

In the next major version some things will be changing in this Project. Will be adding support for Net Standard 1.6 (which means also .NET Core) and instead of using SimpleJson to parse the JSON, _JSON.NET_ will be used. This means there will be some dependencies to other NuGet Packages. But since Net Standard works closly with other NuGet packages there is no big impact. 

## Usage

It's a wrapper of REST api. Read the [GitLab docs](https://github.com/gitlabhq/gitlabhq/tree/master/doc/api) and start using by creating a GitLabClient instance:

```cs
var client = new GitLabClient("https://mygitlab.example.com", "your_private_token");
```

or

```cs
var client =  new GitLabClient("https://mygitlab.example.com");
var session = await client.LoginAsync("username", "password");
```

_Username and Password authentication is disabled for users with two-factor authentication turned on [see GitLab Documentation](https://docs.gitlab.com/ce/api/session.html)._

Then use its properties. You can obtain the private token in your account page. You may want to create a custom user for the API usage.

## Where can I get it?

Get it from NuGet. You can simply install it with the Package Manager console:

    PM> Install-Package NGitLab
    
## Unit-Test

Unit tests are run against a GitLab Server. Use a docker container to host a GitLab Server:

```
docker run --detach --hostname gitlab.example.com --publish 443:443 --publish 80:80 --publish 2222:22 --name gitlab --restart always --volume /srv/gitlab/config:/etc/gitlab --volume /srv/gitlab/logs:/var/log/gitlab --volume /srv/gitlab/data:/var/opt/gitlab gitlab/gitlab-ce:latest
```

## Maintainer

Big thanks to @Scooletz to bringing this project to life. I am happy to continue his work.
