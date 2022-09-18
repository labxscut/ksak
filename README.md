# Ksak: A High-throughput Tool for Alignment-free Phylogenetics

# README

## Introduction

- Phylogenetic analysis is the cornerstone of evolutionary biology and taxonomy. Phylogeny based on molecular sequence similarity has become the de facto standard. All subsequences of size k derived from a molecular sequence, are called its k-mers. Numerous studies demonstrated that k-mers of molecular sequences, such as genomic DNA, are conserved within closely related organisms, and diverge with speciation (Huan et al., 2015, Yu et al., 2019). Thus k-mer statistics are efficient and effective phylogenetic distance measures (Bussi et al., 2021).

- We developed Ksak - a tool efficiently computes seven widely accepted k-mer statistics: Chebyshev (Ch), Manhattan (Ma), Euclidian (Eu), Hao (Qi et al., 2004), d2, d2S and d2star (Song et al., 2013); and performs alignment-free phylogenetic analysis. Using a golden standard 16S rRNA dataset, we extensively benchmarked the accuracy and efficiency of Ksak, comparing to Muscle (Edgar et al., 2004), ClustalW2 (Panchal et al., 2012) , Mafft (Katoh et al., 2014) and Cafe(Sun et al., 2017) - popular multiple sequence aligners. We made the software of Ksak open source. Ksak runs on MS Windows and Linux operating systems with a graphical user interface for Windows.

![image](images/0.png)

<center>Fig. 1. (a) The computation framework of <i>Ksak</i>; (b) Accuracy benchmark results; (c) Efficiency benchmark results; (d) An example phylogeny tree output of <i>Ksak</i>.</center>

***
## Manual (Windows)

## <b> 1. User interface of <i>Ksak</i> </b>

![image](images/image1.png)

<center>Fig. 2. The user interface of <i>Ksak</i> is shown below.</center>

### 1.1. Main menu

- The red area is the <b>main menu</b>, where you can set the language, graphic font and other options. The yellow area is the <b>input sequences</b>, where you can view and edit the sequences highlight colors. The green area is the <b>configuration panel</b>, where you can configure the options of clustering and plotting algorithm, etc. The blue area is the <b>output panel</b>, where you can view and export the generated tree. The purple area is the <b>status bar</b>, where the current progress of calculation and plotting is displayed.

### 1.2. Configuration panel

- This panel is used to configure the calculation parameters, in the <i><u>Distance</u></i> multiple selector one can configure which distance algorithm is needed for the calculation; in the <i><u>k-string length</u></i> field one can configure the interval information of k-string length; in the <i><u>Markov model</u></i> field one can configure the interval information of Markov model; in the <i><u>Tree Constrcution Method</u></i> field one can configure the clustering algorithm (UPGMA or NJ).

### 1.3. Status bar

- After importing and configuring the sequences, one can click <i><u>Generate</u></i> button to see the software starting to run. The running progress can be seen in this area.

### 1.4. Output panel

- After the calculation is complete, the obtained tree is presented on the <i><u>Output panel</u></i> of the software. We can select different results and view them, and we can also view different styles of trees (Standard and Circular). Meanwhile, right clicking on the output image one can choose <i><u>Save</u></i> or <i><u>Save All ...</u></i> to export the results (bmp image, tree description file or distance matrix) for that or all plots, respectively. Double-click the image, then it can be viewed separately in a pop-up box.

- For example, we input the comparison sequence in the <i><u>Iutput sequences</u></i> and run as follows, which allows us to export the evolutionary tree directly.

![image2](images/image2.png)

<center>Fig. 3. Running example of <i>Ksak</i>.</center>

## <b> 2. Advantages of <i>Ksak</i></b>

- Multiple windows can be opened for easy comparison from tree to tree.
Very full-featured: Upgrading on <i>Ksak</i> allows you to produce plots, mark colors, and set fonts with one click.

- Time Upgrading: Using the technology of separating interaction and calculation, the efficiency is 20% more efficient on the basis of <i>Ksak</i>.

- Language support Chinese and English.

## <b> 3. Features of <i>Ksak</i></b>

- The software is roughly divided into three columns. The left column is used for input, click the <i><u>Clear</u></i> button to clear the input sequence; click <i><u>Add</u></i> to import the sequence file by opening the input dialog box as shown in the figure; meanwhile, the <i><u>Input</u></i> box also accepts file/folder drag-and-drop operation and will automatically find the fasta format file in the folder to import; double click the sequence file name to view the sequence information.

![image3](images/image3.png)

- In addition, we can right click on the sequence name in the shortcut menu to select the sequence color and mark it. The sequences are color categorized before sequence comparison. The output evolution tree is very clear in this way, as follows.

![image4](images/image4.png)

- After the software upgrade, <i>Ksak</i> can have two types of clustering output, including UPGMA clustering and NJ clustering. The following figure shows the output results of both clusters.

### a) UPGMA clustering

![image5](images/image5.png)

### b) NJ clustering

![image6](images/image6.png)

- In addition, the output of <i>Ksak</i> can be saved in three ways after the upgrade. The first one is image output, and you can output all the plots under all parameters at once and save them in one folder. The second output is in matrix form, where the results of all runs under all parameters are saved in matrix form and stored in the same folder, and saved in the parameter format. The third output format can be saved as a notepad, where all sequences are output in the format described under different parameters. The three ways are shown in the figure.

![image7](images/image7.png)

- For the output results in the form of evolution trees, we can upgrade the output to the following 7 presentation formats. The evolution tree allows us to visualize the different clustering effects and the clustering effect of species.

### a) Standard

![image8](images/1.png)

### b) Circular

![image9](images/2.png)

### c) Align Text

![image10](images/3.png)

### d) Triangular

![image11](images/4.png)

### e) Bezier

![image12](images/5.png)

### f) Circular Triangular

![image13](images/6.png)

### g) Circular Bezier

![image14](images/7.png)

## <b>Reference:</b>

Lu, Y.Y., Tang, K., et al. (2017) CAFE: accelerated Alignment-Free sequence analysis. Nucleic Acids Res.45,W554-W559.

Edgar, R.C. (2004) MUSCLE: a multiple sequence alignment method with re-duced time and space complexity. BMC Bioinformatics, 5, 113.

Patel, S., Panchal, H. and Anjaria, K. (2012) Phylogenetic analysis of some legu-minous trees using CLUSTALW2 bioinformatics tool. Bioinformatics and Bio-medicine Workshops (BIBMW), 917–921.

Katoh, K. (2014) MAFFT: iterative refinement and additional methods. Methods Mol. Biol., 1079, 131–146.

Lu, Y.Y., Tang, K., et al. (2017) CAFE: accelerated Alignment-Free sequence analysis. Nucleic Acids Res.45,W554-W559.


***
# <b>Contact & Support:</b>

- Li C. Xia: email: lcxia@scut.edu.cn

- Xuemei Liu: email: liuxm@scut.edu.cn

- Ziqi Cheng: email: php@mail.scut.edu.cn
