using System;

namespace FuzzyScore.Net.Test;

public class Tests
{
    [Test]
    public void NullQueryThrows()
    {
        Assert.That(
            () => FuzzyScore.Score("not null", null!),
            Throws.TypeOf<ArgumentNullException>()
        );
    }

    [Test]
    public void NullTermThrows()
    {
        Assert.That(
            () => FuzzyScore.Score(null!, "not null"),
            Throws.TypeOf<ArgumentNullException>()
        );
    }

    [Test]
    public void NullParametersThrows()
    {
        Assert.That(() => FuzzyScore.Score(null!, null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void EmptyStringsReturnsZero()
    {
        Assert.That(FuzzyScore.Score("", ""), Is.EqualTo(0));
    }

    [Test]
    public void WorkshopBReturnsZero()
    {
        Assert.That(FuzzyScore.Score("Workshop", "b"), Is.EqualTo(0));
    }

    [Test]
    public void RoomOReturnsOne()
    {
        Assert.That(FuzzyScore.Score("Room", "o"), Is.EqualTo(1));
    }

    [Test]
    public void WorkshopWReturnsOne()
    {
        Assert.That(FuzzyScore.Score("Workshop", "w"), Is.EqualTo(1));
    }

    [Test]
    public void WorkshopWsReturnsTwo()
    {
        Assert.That(FuzzyScore.Score("Workshop", "ws"), Is.EqualTo(2));
    }

    [Test]
    public void WorkshopWoReturnsFour()
    {
        Assert.That(FuzzyScore.Score("Workshop", "wo"), Is.EqualTo(4));
    }

    [Test]
    public void ASFReturnsThree()
    {
        Assert.That(FuzzyScore.Score("Apache Software Foundation", "asf"), Is.EqualTo(3));
    }
}
