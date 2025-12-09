using System;

namespace FuzzyScore.Net;

public static class FuzzyScorer
{
    /// <summary>
    /// Computes a fuzzy similarity score between a target <paramref name="term"/>
    /// and a <paramref name="query"/> string using the FuzzyScore algorithm.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// This method is a .NET port of the Apache Commons Text
    /// <see href="https://commons.apache.org/proper/commons-text/apidocs/org/apache/commons/text/similarity/FuzzyScore.html">
    /// FuzzyScore algorithm
    /// </see>.
    /// </para>
    ///
    /// <para>
    /// The algorithm assigns:
    /// <list type="bullet">
    ///   <item>
    ///     <description>+1 point for every character in <paramref name="query"/> that appears in <paramref name="term"/> in order.</description>
    ///   </item>
    ///   <item>
    ///     <description>+2 bonus points for each consecutive character match based on the previous match position.</description>
    ///   </item>
    /// </list>
    /// Characters must appear in sequence, but not necessarily contiguously.
    /// If any character from <paramref name="query"/> cannot be found in order
    /// inside <paramref name="term"/>, the method returns <c>0</c>.
    /// </para>
    ///
    /// <para>
    /// Both strings are normalized using <see cref="string.ToLowerInvariant"/> and trimmed
    /// prior to scoring.
    /// </para>
    ///
    /// <para><b>Examples (from Apache Commons FuzzyScore):</b></para>
    /// <example>
    /// <code>
    /// Score(null, null)                           = throws ArgumentNullException
    /// Score("not null", null)                     = throws ArgumentNullException
    /// Score(null, "not null")                     = throws ArgumentNullException
    /// Score("", "")                               = 0
    /// Score("Workshop", "b")                      = 0
    /// Score("Room", "o")                          = 1
    /// Score("Workshop", "w")                      = 1
    /// Score("Workshop", "ws")                     = 2
    /// Score("Workshop", "wo")                     = 4
    /// Score("Apache Software Foundation", "asf")  = 3
    /// </code>
    /// </example>
    /// </remarks>
    ///
    /// <param name="term">
    /// The string to be searched. Must not be <c>null</c>.
    /// </param>
    ///
    /// <param name="query">
    /// The query string whose characters must appear (in order) within <paramref name="term"/>.
    /// Must not be <c>null</c>.
    /// </param>
    ///
    /// <returns>
    /// The total fuzzy similarity score. A higher score indicates a closer match.
    /// Returns <c>0</c> if any character in <paramref name="query"/> is not found in order
    /// within <paramref name="term"/>.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="term"/> or <paramref name="query"/> is <c>null</c>.
    /// </exception>
    public static int Score(string term, string query)
    {
        if (term is null)
        {
            throw new ArgumentNullException(
                nameof(term),
                "The term passed into FuzzyScore.Score(term, query) cannot be null."
            );
        }

        if (query is null)
        {
            throw new ArgumentNullException(
                nameof(query),
                "The query passed into FuzzyScore.Score(term, query) cannot be null."
            );
        }

        term = term.ToLowerInvariant().Trim();
        query = query.ToLowerInvariant().Trim();

        int score = 0;
        int termPosition = 0;
        int previousMatchPosition = int.MinValue;

        foreach (char queryCharacter in query)
        {
            bool found = false;

            for (int i = termPosition; i < term.Length; i++)
            {
                if (queryCharacter != term[i])
                {
                    continue;
                }

                score += 1;

                // bonus points for consecutive character matches
                if (previousMatchPosition + 1 == i)
                {
                    score += 2;
                }

                previousMatchPosition = i;
                termPosition = i + 1;
                found = true;

                break;
            }

            if (!found)
            {
                return 0;
            }
        }

        return score;
    }
}
