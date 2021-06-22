using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest
{
    /// <summary>
    /// UUID class
    /// </summary>
    public class Uuid
    {
        /// <summary>
        ///  Takes one string input of any number of integers separated by single whitespace. 
        ///  The function then outputs the longest increasing subsequence (increased by any number) present in that sequence. 
        ///  If more than 1 sequence exists with the longest length, output the earliest one. 
        /// </summary>
        /// <param name="input">Any number of integers separated by single whitespace</param>
        /// <returns>The longest increasing subsequence</returns>
        public string GetLis(string input)
        {
            // return empty string if input is null or blank
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            // list that will store the LIS 
            var resultSequence = new List<int>();
            
            // list for increasing sequence calculation 
            var calcSequence = new List<int>();

            // split input by whitespace
            string[] numbers = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // loop through all number and try to find LIS
            foreach (string textValue in numbers)
            {
                if (!int.TryParse(textValue, out var currentNumber))
                {
                    // It's not an integer, get next number
                    // This is not expected. It's input issue, could throw exception.
                    continue;
                }

                // get last value in the increasing sequence 
                int? lastValueInSequence = calcSequence.Count == 0 ? null : calcSequence[^1]; 
                
                // compare current number with last value in the sequence 
                if (lastValueInSequence == null || currentNumber > lastValueInSequence)
                {
                    // since the value is increase, add the number to the sequence
                    calcSequence.Add(currentNumber);
                    continue;
                }

                // Update result if the sequence is longer
                CompareAndUpdateResultSequence(calcSequence, ref resultSequence);
                
                // initialize sequence for next calculation
                InitializeSequence(ref calcSequence, currentNumber);
            }
            
            // Now out of the loop, the last number in the input could in an increasing sequence
            // and that sequence could be the longest one.
            // So, need to compare calc sequence with result sequence again.
            CompareAndUpdateResultSequence(calcSequence, ref resultSequence);

            // final result
            var lisResult = string.Join(" ", resultSequence);
            return lisResult;
        }

        // Initialize Calc Sequence
        private void InitializeSequence(ref List<int> calcSequence, int firstInteger)
        {
            calcSequence.Clear();
            calcSequence.Add(firstInteger);
        }

        /// <summary>
        /// If the intermediate sequence longer the original result,
        /// then it potentially be the longest sequence. 
        /// </summary>
        /// <param name="calcSequence">increasing sequence in the calc</param>
        /// <param name="resultSequence">result increasing sequence</param>
        private void CompareAndUpdateResultSequence(List<int> calcSequence, ref List<int> resultSequence)
        {
            if (calcSequence.Count > resultSequence.Count)
            {
                // got longer increasing sequence
                // update result
                resultSequence = calcSequence.ToList();
            }
        }

    }
}