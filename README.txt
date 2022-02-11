
The folder Code includes the solution and projects developed to address the technical test.

The forlder Exe includes the executable file, and should be accessed for testing.

How to test:

	1 - Open a command prompt window positioned at the Exe folder:
	
	2 - Start the aplication with one of the following commands, depending of which of the solution approches you want to test (tree or graph):
			
			BluePrismTechnicalTest.exe -tree data\words-english.txt
			
			OR

			BluePrismTechnicalTest.exe -graph data\words-english.txt
			
	3 - To test the paths between words it must be inputed commands of type: 
			
			word1;word2[;output file] 
			
			Note: If the output file is missing, the output is printed to the console.
			
			Examples:
			
				SAME;COST
				
				SAME;COST;c:\temp\result.txt