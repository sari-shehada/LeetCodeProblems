using System.Numerics;

namespace LeetCodeProblems.Medium;


// https://leetcode.com/problems/add-two-numbers/description/
// You are given two non-empty linked lists representing two non-negative integers.
// The digits are stored in reverse order, and each of their nodes contains a single digit.
// Add the two numbers and return the sum as a linked list.
//
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.

// TODO: Re-visit later 
public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}
 
public class AddTwoNumbers
{
    
    public static ListNode Solve(ListNode l1, ListNode l2)
    {
        var firstNumber = BigInteger.Parse(GetNumberAsString(l1));
        var secondNumber = BigInteger.Parse(GetNumberAsString(l2));
        var result = (firstNumber + secondNumber).ToString().ToList();
        result.Reverse();
        return ConvertNumberToNode(result);
    }


   public static ListNode? ConvertNumberToNode(List<char> number)
    {
        if (number.Count == 0)
        {
            return null;
        }
        var digit = int.Parse(number.First().ToString());
        number.RemoveAt(0);
        return new ListNode()
        {
            val = digit,
            next = ConvertNumberToNode(number),
        };
    }
    public static string GetNumberAsString(ListNode node)
    {
        List<char> number = new List<char>();
        while (node.next!=null)
        {
            number.Add(char.Parse(node.val.ToString()));
            node=node.next;
        }
        number.Add(char.Parse(node.val.ToString()));
        number.Reverse();
        return string.Join("", number);
    }
    
    public static ListNode? ConvertNumberToNode(List<int> number)
    {
        return ConvertNumberToNode(number
            .Select(e => char.Parse(e.ToString()))
            .ToList());
    }
}