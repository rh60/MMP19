#include "pch.h"
#include <iostream>
#include "Polynomial.h"

using namespace MMP;

int main()
{
	vector<double> a{ 1,2,3 };
	Polynomial<double> p(a);
	for (auto c : a)
		std::cout << c << ' ';
	std::cout << std::endl << p(2) << std::endl;
}
