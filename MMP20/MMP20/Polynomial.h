#pragma once
#include <vector>

namespace MMP
{	
	using namespace std;	

	template <typename scalar>
	class Polynomial
	{
	private:
		vector<scalar> a;
	public:
		Polynomial(vector<scalar>);
		Polynomial();
		scalar operator()(scalar);
		Polynomial<scalar> MultiplyByFactor(scalar);
		static Polynomial<scalar> OfRoots(vector<scalar>);
		~Polynomial();
	};

	template <typename scalar>
	Polynomial<scalar>::Polynomial(vector<scalar> coefficients)
	{
		if (coefficients.size() > 0)
			a = coefficients;
		else
			a.push_back(0);
	}

	template <typename scalar>
	Polynomial<scalar>::~Polynomial()
	{
		a.push_back(0);
	}

	template<typename scalar>
	inline Polynomial<scalar>::Polynomial()
	{
	}

	template <typename scalar>
	inline scalar Polynomial<scalar>::operator()(scalar x)
	{
		scalar r = a[0];
		for (int i = 1; i < a.size(); i++)
			r = r * x + a[i];
		return r;
	}

	template<typename scalar>
	inline Polynomial<scalar> Polynomial<scalar>::MultiplyByFactor(scalar c)
	{
		vector<double> a1(a.size() + 1);			
		for (int i = 0; i < a.size(); i++)
		{
			a1[i] += a[i];
			a1[i + 1] -= c * a[i];
		}
		return Polynomial(a1);
	}

	template<typename scalar>
	inline Polynomial<scalar> Polynomial<scalar>::OfRoots(vector<scalar> roots)
	{
		if (roots.size() == 0)
			return Polynomial();
		vector<scalar> a(roots.size() + 1);
		a[0] = 1;
		for (int i = 0; i < roots.size(); i++)
		{
			if (roots[i] != 0.0)
				for (int j = i + 1; j > 0; j--)
					a[j] -= roots[i] * a[j - 1];
		}	
		return Polynomial(a);
	}
}