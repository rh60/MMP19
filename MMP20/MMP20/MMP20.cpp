// MMP20.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include "Polynomial.h"

using namespace MMP;

int main()
{
	vector<scalar> a{ 1,2,3 };
	Polynomial p(a);
	std::cout << "Hello World!\n"; 
}
