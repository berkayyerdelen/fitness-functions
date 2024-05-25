using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using FitnessFunctions.Definition.Contracts;
using FitnessFunctions.Domain;
using FitnessFunctions.SharedKernel.Messaging;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace FitnessFunctions.Definition.Tests;

public class ContractTests
{
    private static readonly Architecture Architecture =
        new ArchLoader().LoadAssemblies(typeof(UserCreatedIntegrationEvent).Assembly,
            typeof(Product).Assembly).Build();
    
    [Fact]
    public void Given_Messages_Implement_MarkerContract()
    {
        var coreNameSpace = "FitnessFunctions.Definition.Contracts";

        IArchRule rule = ArchRuleDefinition
            .Classes()
            .That()
            .ResideInNamespace(coreNameSpace)
            .Should()
            .ImplementInterface(typeof(IMessage));
        rule.Check(Architecture);
    }

    [Fact]
    public void Given_Messages_Should_Have_EventOrCommandPrefix()
    {
        var coreNameSpace = "FitnessFunctions.Definition.Contracts";

        IArchRule rule = ArchRuleDefinition
            .Classes()
            .That()
            .ResideInNamespace(coreNameSpace)
            .Should().FollowCustomCondition(x => x.Name.EndsWith("Event") || x.Name.EndsWith("Command"),
                "Given contracts should contain Event or Command",
                "fail");
        rule.Check(Architecture);
    }

    [Fact]
    public void Given_Messages_Must_Be_SealedClasses()
    {
        var coreNameSpace = "FitnessFunctions.Definition.Contracts";

        IArchRule rule = ArchRuleDefinition
            .Classes()
            .That()
            .ResideInNamespace(coreNameSpace).Should().BeSealed();

        rule.Check(Architecture);
    }

    [Fact]
    public void Definition_Should_Not_Use_DomainLayer_Definitions()
    {
        var coreNameSpace = "FitnessFunctions.Definition.Contracts";
        var domainLayer = "FitnessFunctions.Domain";
     
        IObjectProvider<IType> coreClasses = ArchRuleDefinition.Types().That().ResideInNamespace(coreNameSpace);
        IObjectProvider<IType> infrastructureClasses = ArchRuleDefinition.Types().That().ResideInNamespace(domainLayer);

        IArchRule rule = ArchRuleDefinition.Types()
            .That().Are(coreClasses)
            .Should().NotDependOnAny(infrastructureClasses)
            .Because("Core should not depend on Infrastructure");

        rule.Check(Architecture);
    }
}