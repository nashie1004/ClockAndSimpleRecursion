using System;

namespace RecursionApp
{
	public class Branch
	{
        public List<Branch> branches = new List<Branch>();
		public string Name { get; set; } = "";
		public Branch? Parent { get; set; } = null;
		public void AddBranch(Branch? branch, Branch? parent)
		{
			if (branch != null)
			{
				branches.Add(branch);
			}
			Parent = parent;
		}

	}
	public class Recursion
	{
		static int DepthCount { get; set; } = 0;
		static int TempDepthCount { get; set; } = 1;
		public static void Main(string[] args)
		{
			Branch branchA = new Branch() { Name = "a" };
			Branch branchB = new Branch() { Name = "b" };
			Branch branchC = new Branch() { Name = "c" };
			Branch branchD = new Branch() { Name = "d" };
			Branch branchE = new Branch() { Name = "e" };
			Branch branchF = new Branch() { Name = "f" };
			Branch branchG = new Branch() { Name = "g" };
			Branch branchH = new Branch() { Name = "h" };
			Branch branchI = new Branch() { Name = "i" };
			Branch branchJ = new Branch() { Name = "j" };
			Branch branchK = new Branch() { Name = "k" };

			// simple example
			//branchA.AddBranch(branchB, null);
			//branchB.AddBranch(branchC, branchA);
			//branchC.AddBranch(branchD, branchB);
			//branchD.AddBranch(branchE, branchC);

			// main example
			branchA.AddBranch(branchB, null);
			branchB.AddBranch(branchD, branchA);
			branchD.AddBranch(null, branchB);

			branchA.AddBranch(branchC, null);
			branchC.AddBranch(branchE, branchA);
			branchE.AddBranch(branchH, branchC);
			branchH.AddBranch(null, branchE);

			branchC.AddBranch(branchF, branchA);
			branchF.AddBranch(branchI, branchC);
			branchI.AddBranch(branchK, branchF);
			branchK.AddBranch(null, branchI);

			branchF.AddBranch(branchJ, branchC);
			branchJ.AddBranch(null, branchF);

			branchC.AddBranch(branchG, branchA);
			branchG.AddBranch(null, branchC);

			CalculateDepth(branchA);
            Console.WriteLine("\nDepth: " + DepthCount);
		}
		static void CalculateDepth(Branch branch)
		{
            if (branch.Parent != null)
			{
				TempDepthCount = 1;
				Branch parentBranch = branch;

				if (parentBranch.Parent.Name == "a")
				{
					Console.Write("Iterate: " + parentBranch.Name + " --> " + parentBranch.Parent.Name);
				} 
				else
				{
                    Console.Write("Iterate: " + parentBranch.Name);
                }
                while (branch.Parent.Name != "a" && parentBranch.Parent != null)
				{
					Console.Write(" --> " + parentBranch.Parent.Name);
					parentBranch = parentBranch.Parent;
					TempDepthCount++;

					if (DepthCount < TempDepthCount)
					{
						DepthCount = TempDepthCount;
					}
				}
				Console.Write($" = {TempDepthCount}");
				Console.WriteLine("");
			}
			if (branch.branches.Count == 0 )
			{
                return;
			}
			else
			{
				foreach (Branch subBranch in branch.branches)
				{
                    CalculateDepth(subBranch);
				}
			}
		}
	}
}