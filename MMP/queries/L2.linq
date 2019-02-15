<Query Kind="Statements">
  <Namespace>MathNet.Numerics.LinearAlgebra</Namespace>
  <Namespace>MathNet.Numerics.LinearAlgebra.Double</Namespace>
</Query>

Matrix<double> A = DenseMatrix.OfArray(new double[,] {
        {1,1,1,1},
        {1,2,3,4},
        {4,3,2,1}});
Vector<double>[] nullspace = A.Kernel();

A *= 2;

A.Dump();
nullspace.Dump();