using System;

namespace FuzzyScore.Net.Test;

public class FuzzyScorerTest
{
    [Test]
    public void NullQueryThrows()
    {
        Assert.That(
            () => FuzzyScorer.Score("not null", null!),
            Throws.TypeOf<ArgumentNullException>()
        );
    }

    [Test]
    public void NullTermThrows()
    {
        Assert.That(
            () => FuzzyScorer.Score(null!, "not null"),
            Throws.TypeOf<ArgumentNullException>()
        );
    }

    [Test]
    public void NullParametersThrows()
    {
        Assert.That(() => FuzzyScorer.Score(null!, null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void EmptyStringsReturnsZero()
    {
        Assert.That(FuzzyScorer.Score("", ""), Is.EqualTo(0));
    }

    [Test]
    public void WorkshopBReturnsZero()
    {
        Assert.That(FuzzyScorer.Score("Workshop", "b"), Is.EqualTo(0));
    }

    [Test]
    public void RoomOReturnsOne()
    {
        Assert.That(FuzzyScorer.Score("Room", "o"), Is.EqualTo(1));
    }

    [Test]
    public void WorkshopWReturnsOne()
    {
        Assert.That(FuzzyScorer.Score("Workshop", "w"), Is.EqualTo(1));
    }

    [Test]
    public void WorkshopWsReturnsTwo()
    {
        Assert.That(FuzzyScorer.Score("Workshop", "ws"), Is.EqualTo(2));
    }

    [Test]
    public void WorkshopWoReturnsFour()
    {
        Assert.That(FuzzyScorer.Score("Workshop", "wo"), Is.EqualTo(4));
    }

    [Test]
    public void ASFReturnsThree()
    {
        Assert.That(FuzzyScorer.Score("Apache Software Foundation", "asf"), Is.EqualTo(3));
    }
}
