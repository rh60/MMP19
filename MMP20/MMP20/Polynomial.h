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
		scalar operator()(scalar);
		~Polynomial();

	};

	template <typename scalar>
	Polynomial<scalar>::Polynomial(vector<scalar> coefficients)
	{
		a = coefficients;
	}

	template <typename scalar>
	inline scalar Polynomial<scalar>::operator()(scalar x)
	{
		scalar r = a[0];
		for (int i = 1; i < a.size(); i++)
			r = r * x + a[i];
		return r;
	}

	template <typename scalar>
	Polynomial<scalar>::~Polynomial()
	{
	}

}