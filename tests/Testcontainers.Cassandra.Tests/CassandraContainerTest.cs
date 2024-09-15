using System.Net;
using Cassandra;

namespace Testcontainers.Cassandra.Tests
{
  public class CassandraContainerTest : IAsyncLifetime
  {
    private readonly CassandraContainer _cassandraContainer = new CassandraBuilder().Build();

    public Task InitializeAsync()
    {
      return _cassandraContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
      return _cassandraContainer.DisposeAsync().AsTask();
    }

    [Fact]
    [Trait(nameof(DockerCli.DockerPlatform), nameof(DockerCli.DockerPlatform.Linux))]
    public void ConnectionStateReturnsOpen()
    {
      // Given
      var cluster = Cluster.Builder()
        .AddContactPoint(_cassandraContainer.GetEndPoint())
        .Build();

      // When
      var session = cluster.Connect();

      // Then
      Assert.True(session.GetState().GetConnectedHosts().First().IsUp);
    }

    [Fact]
    [Trait(nameof(DockerCli.DockerPlatform), nameof(DockerCli.DockerPlatform.Linux))]
    public async Task ExecScriptReturnsSuccessful()
    {
      // Given
      const string scriptContent = "SELECT * FROM system.local;";

      // When
      var execResult = await _cassandraContainer.ExecScriptAsync(scriptContent)
        .ConfigureAwait(true);

      // Then
      Assert.True(0L.Equals(execResult.ExitCode), execResult.Stderr);
      Assert.Empty(execResult.Stderr);
    }
  }
}
