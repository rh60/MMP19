#pragma once
#include <vector>


namespace MMP
{	
	using namespace std;
	typedef double scalar;

	class Polynomial
	{
	private:
		vector<scalar> a;
	public:
		Polynomial(vector<scalar>);
		~Polynomial();
	};


	Polynomial::Polynomial(vector<scalar> coefficients)
	{
		a = coefficients;
	}


	Polynomial::~Polynomial()
	{
	}

}