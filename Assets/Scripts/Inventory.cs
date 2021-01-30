using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
	private static int food = 1;
	public static int GetQuantity(int counter)
	{
		int result = 0;
		switch (counter)
		{
			case 2:
				result = food;
				break;
			case 3:
				result =  0;
				break;
			case 4:
				result = 0;
				break;
			case 5:
				result = 0;
				break;
		}
		return result;
	}
	public static void IncreaseQuantity(int counter, int increasequantity = 1)
	{
		switch (counter)
		{
			case 2:
				food+=increasequantity;
				break;
		}
	}

	public static void DecreaseQuantity(int counter, int decreasequantity = 1)
	{
		IncreaseQuantity(counter, -decreasequantity);
	}

	public static bool Throwable(int counter)
	{
		bool result = false;
		switch (counter)
		{
			case 1:
				result = true;
				break;
			case 2:
				result = true;
				break;
			case 3:
				result = false;
				break;
			case 4:
				result = false;
				break;
			case 5:
				result = false;
				break;
		}
		return result;
	}
	public static bool Eatable(int counter)
	{
		bool result = false;
		switch (counter)
		{
			case 1:
				result = false;
				break;
			case 2:
				result = true;
				break;
			case 3:
				result = false;
				break;
			case 4:
				result = false;
				break;
			case 5:
				result = false;
				break;
		}
		return result;
	}
}
