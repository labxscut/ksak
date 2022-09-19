![image](images/0.png)

<center>Fig. 1.      (a) The computation framework of <i>Ksak</i>; (b) Accuracy benchmark results; (c) Efficiency benchmark results; (d) An example phylogeny tree output of <i>Ksak</i>.</center>

<b> 1. Operating interface of <i>Ksak</i> </b>

The interface of <i>Ksak</i> is shown below.

![image](images/image1.png)

The red area is the menu area, where you can set the language, graphic font and other information. The yellow area is the input area, where you can view and edit the sequences involved in the comparison. The green area is the configuration area, where you can configure the clustering algorithm, plotting algorithm, etc. The blue area is the output area, where you can view the generated tree and export it here. The purple area is the status area, where you can display the current progress of calculation and plotting.

The software package can compare protein and DNA sequences by clicking <i><u>Gene</u></i> and <i><u>Protein</u></i>.

The middle column is used to configure the calculation parameters, in <i><u>Distance</u></i> column you can configure which distance algorithm is needed for the calculation; in <i><u>k-string length</u></i> you can configure the interval information of k-string length; in <i><u>Malkov model</u></i> you can configure the interval information of Malkov model; in <i><u>Draw Method</u></i> you can configure the clustering algorithm (UPGMA or NJ).

After importing and configuring the sequences, click <i><u>Generate</u></i> button to see the software start running. The running progress can be seen in the status bar at the bottom.

After the calculation is complete, the obtained tree is presented on the right side of the software. We can select different results and view them, and we can also view different styles of trees (Standard and Circular).

Right click on the image and in the shortcut menu you can choose <i><u>Save</u></i> or <i><u>Save All ...</u></i> to export the results (bmp image, tree description file or distance matrix) for that or all plots, respectively. Double click on the image to see it individually in a pop-up box.

For example, in the left column we enter the comparison sequence and run the result as follows, which allows us to export the evolutionary tree directly.

![image2](images/image2.png)

<b>2. Advantages of <i>Ksak</i></b><br>

Multiple windows can be opened for easy comparison from tree to tree.
Very full-featured: Upgrading on <i>Ksak</i> allows you to produce plots, mark colors, and set fonts with one click.

Win. Linux. platform: Has versions for both Windows and Linux platforms.

Time Upgrading: Using the technology of separating interaction and calculation, the efficiency is 20% more efficient on the basis of <i>Ksak</i>.

Language support Chinese and English.

<b>3. Features of <i>Ksak</i></b>

The software is roughly divided into three columns. The left column is used for input, click the <i><u>Clear</u></i> button to clear the input sequence; click <i><u>Add</u></i> to import the sequence file by opening the input dialog box as shown in the figure; meanwhile, the <i><u>Input</u></i> box also accepts file/folder drag-and-drop operation and will automatically find the fasta format file in the folder to import; double click the sequence file name to view the sequence information.

![image3](images/image3.png)

In addition, we can right click on the sequence name in the shortcut menu to select the sequence color and mark it. The sequences are color categorized before sequence comparison. The output evolution tree is very clear in this way, as follows.

![image4](images/image4.png)

After the software upgrade, <i>Ksak</i> can have two types of clustering output, including UPGMA clustering and NJ clustering. The following figure shows the output results of both clusters.

<center>a) UPGMA clustering</center>

![image5](images/image5.png)

<center>b) NJ clustering</center>

![image6](images/image6.png)

In addition, the output of <i>Ksak</i> can be saved in three ways after the upgrade. The first one is image output, and you can output all the plots under all parameters at once and save them in one folder. The second output is in matrix form, where the results of all runs under all parameters are saved in matrix form and stored in the same folder, and saved in the parameter format. The third output format can be saved as a notepad, where all sequences are output in the format described under different parameters. The three ways are shown in the figure.

![image7](images/image7.png)
![image8](images/image8.png)

For the output results in the form of evolution trees, we can upgrade the output to the following 7 presentation formats. The evolution tree allows us to visualize the different clustering effects and the clustering effect of species.

<center>a) Standard</center>

![image9](images/1.png)

<center>b) Circular</center>

![image10](images/2.png)

<center>c) Align Text</center>

![image11](images/3.png)

<center>d) Triangular</center>

![image12](images/4.png)

<center>e) Bezier</center>

![image13](images/5.png)

<center>f) Circular Triangular</center>

![image14](images/6.png)

<center>g) Circular Bezier</center>

![image15](images/7.png)

<b>Reference:</b>

Lu, Y.Y., Tang, K., et al. (2017) CAFE: accelerated Alignment-Free sequence analysis. Nucleic Acids Res.45,W554-W559.

Edgar, R.C. (2004) MUSCLE: a multiple sequence alignment method with re-duced time and space complexity. BMC Bioinformatics, 5, 113.

Patel, S., Panchal, H. and Anjaria, K. (2012) Phylogenetic analysis of some legu-minous trees using CLUSTALW2 bioinformatics tool. Bioinformatics and Bio-medicine Workshops (BIBMW), 917–921.

Katoh, K. (2014) MAFFT: iterative refinement and additional methods. Methods Mol. Biol., 1079, 131–146.

Lu, Y.Y., Tang, K., et al. (2017) CAFE: accelerated Alignment-Free sequence analysis. Nucleic Acids Res.45,W554-W559.


<b>Q&A</b>

1. <b>Q: Where can I try this software?</b>

    A: You need to clone or download this project, then locate to <u>bin/Release</u>. After clicking <u>Ksak.exe</u> then you'll see the program immediately.

2. <b>Q: Where can I get test data?</b>
   
   A: We provided some example data in the directory <u>data</u>, you can get the sequence data in <u>sequences</u> or outgroup data in <u>outgroup</u>. You can also use your own sequences data.

3. <b>Q: How to use <u>Ksak.exe</u> analysis the given example data?</b>
   
   A:
      
       1. click to run Ksak.exe in [bin/Release];
       2. click "Add" button in "Input" group, then pick the sequences in [data/sequences] (Hold "Shift" key to multi-select);
       3. click menu "Inputs/Add Outgroup", then pick the sequences in [data/outgroup];
       4. check "Eu" (or some others if you like) in "Run Parameters" group, and modify "K - mer length" and "Markov Background Order" (or not), then click "Run" button.
       5. you'll see the tree result in "Output" group.


<b>Contact & Support:</b>

Li C. Xia: email: lcxia@scut.edu.cn

Ziqi Cheng: email: php@mail.scut.edu.cn