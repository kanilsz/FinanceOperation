using NetArchTest.Rules;
using Xunit;

namespace FinanceOperation.Tests.ArchTests;

public class ArchitecturalGovernanceTests
{
    [Fact]
    public void Interaction_Layer_Cannot_Directly_Reference_Domain_Layer()
    {
        // Given
        var types = Types.InCurrentDomain();

        // When
        var result = types.That()
            .ResideInNamespace("FinanceOperation.Api.Interaction")
            .ShouldNot()
            .HaveDependencyOn("FinanceOperation.Api.Domain")
            .GetResult();

        // Then
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Core_Layer_Cannot_Depend_From_Higher_Layers()
    {
        // Given
        var types = Types.InCurrentDomain();

        // When
        var result = types.That()
            .ResideInNamespace("FinanceOperation.Api.Core")
            .ShouldNot()
            .HaveDependencyOn("FinanceOperation.Api.Interaction")
            .And()
            .HaveDependencyOn("FinanceOperation.Api.Infrastructure")
            .GetResult();

        // Then
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Interfaces_Name_Should_Start_With_I()
    {
        // Given
        var types = Types.InCurrentDomain();

        // When
        var result = types.That()
            .AreInterfaces()
            .Should()
            .HaveNameStartingWith("I")
            .GetResult();

        // Then
        Assert.True(result.IsSuccessful);
    }
}
