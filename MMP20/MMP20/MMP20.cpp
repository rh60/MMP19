#include "pch.h"
#include <iostream>
#include "Polynomial.h"

using namespace MMP;

int main()
{
	vector<double> z;
	Polynomial<double> zero(z);
	vector<double> a{ 1,2,3 };
	Polynomial<double> p(a);
	auto q = p.MultiplyByFactor(1);
	vector<double> roots{ 0,1,2,3,4 };

	auto poly = Polynomial<double>::OfRoots(roots);
	for (auto r : roots)
		cout << r << ' ' << poly(r) << endl;

	p.Print(cout); cout << endl;
	q.Print(cout); cout << endl;
	poly.Print(cout); cout << endl;
}
