#pragma once
#include <vector>
#include <string>
#include <ostream>
#include <cmath>

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
		int Degree() const;
		scalar operator()(scalar);
		Polynomial<scalar> MultiplyByFactor(scalar);
		void Print(ostream&) const;
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

	template<typename scalar>
	inline int Polynomial<scalar>::Degree() const
	{
		return a.size()-1;
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
	inline void Polynomial<scalar>::Print(ostream & out) const
	{
		auto d = Degree();
		if (d == 0)
		{
			out << a[0];
			return;
		}
		for (auto c : a)
		{
			if (c != 0.0)
			{
				if (d < Degree())
					if (c > 0.0)
						out << "+";
					else
						out << "-";
				auto ac = fabs(c);
				if (ac != 1 || d == 0)
					out << ac;
				if (d > 1)
					out << "x^" << d;
				else if (d == 1)
					out << "x";
			}
			d--;
		}
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