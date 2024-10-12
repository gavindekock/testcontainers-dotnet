global using System;
global using System.Collections.Generic;
global using System.Globalization;
global using System.IO;
global using System.Linq;
global using System.Net;
global using System.Net.Sockets;
global using System.Text;
global using System.Threading;
global using System.Threading.Tasks;
global using Docker.DotNet.Models;
global using DotNet.Testcontainers;
global using DotNet.Testcontainers.Builders;
global using DotNet.Testcontainers.Clients;
global using DotNet.Testcontainers.Commons;
global using DotNet.Testcontainers.Configurations;
global using DotNet.Testcontainers.Containers;
global using ICSharpCode.SharpZipLib.Tar;
global using JetBrains.Annotations;
global using Microsoft.Extensions.Logging.Abstractions;
global using Microsoft.Extensions.Logging.Testing;
global using ReflectionMagic;
global using Xunit;