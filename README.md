# Ksak: A High-throughput Tool for Alignment-free Phylogenetics

# README

## Introduction

- Phylogenetic analysis is the cornerstone of evolutionary biology and taxonomy. Phylogeny based on molecular sequence similarity has become the de facto standard. All subsequences of size k derived from a molecular sequence are called its k-mers. Numerous studies demonstrated that k-mers of molecular sequences, such as genomic DNA and proteins are conserved within closely related organisms, and diverge with speciation (Huan et al., 2015, Yu et al., 2019). Thus k-mer statistics are efficient and effective phylogenetic distance measures (Bussi et al., 2021).

- We developed Ksak - a tool that not only efficiently computes seven widely accepted k-mer statistics: Chebyshev (Ch), Manhattan (Ma), Euclidian (Eu), Hao (Qi et al., 2004), d2, d2S and d2star (Song et al., 2013), but also performs alignment-free phylogenetic analysis. By applying of the golden standard 16S rRNA dataset, we extensively benchmarked the accuracy and efficiency of Ksak by comparing to other popular multiple sequence aligners：Muscle (Edgar et al., 2004), ClustalW2 (Panchal et al., 2012), Mafft (Katoh et al., 2014) and Cafe(Sun et al., 2017). We made the software of Ksak open source. Ksak runs on MS Windows operating systems with a graphical user interface for Windows.

![image](images/0.png)

<center>Fig. 1. (a) The computation framework of <i>Ksak</i>; (b) Accuracy benchmark results; (c) Efficiency benchmark results; (d) An example phylogeny tree output of <i>Ksak</i>.</center>

***
## Install

### 1. Where can I try <i>Ksak</i>?

- You need to clone or download this project, then locate to <b>[bin/Release]</b>. After clicking <i><b>Ksak.exe</b></i>, you'll see the program immediately.

### 2. Where can I get the test data?
   
- We have provided some example data in the directory <b>[data]</b>, you can get some sequence data in <b>[sequences]</b> or outgroup data in <u>[outgroup]</u>. You can also use your own data.

### 3. How to use <i><b>Ksak.exe</b></i> to analyze the given example data?
   
- Click to run <i>Ksak.exe</i> in [bin/Release];
- Click <i>Add</i> button in <i>Input</i> panel, then pick the sequences in [data/sequences] (Hold <i>Shift</i> key to multi-select);
- Click <i>Inputs/Add Outgroup</i> in the main menu, then pick the sequences in [data/outgroup];
- Check <i>Eu</i> (or some others if you like) in <i>Configuraion panel</i>, and modify <i>K-mer length</i> and <i>Markov Background Order</i> (or not), then click <i>Run</i> button.
- The results will appeared in <i>Output</i> panel.

***
## Manual (Windows)

## 1. User interface of <i>Ksak</i>

![image](images/image1.png)

<center>Fig. 2. The user interface of <i>Ksak</i> is shown below.</center>

### 1.1. Main menu

- The red area is the <b>main menu</b>, where you can set the language, graphic font and other options. The yellow area is the input sequences, where you can view and edit the sequences with highlight colors. The green area is the <b>configuration panel</b>, where you can configure the options of clustering and plotting algorithm, etc. The blue area is the <b>output panel</b>, where you can view and export the generated tree. The purple area is the <b>status bar</b>, where the current progress of calculation and plotting is displayed.

### 1.2. Configuration panel

- This panel is used to configure the calculation parameters, in the <i><u>Distance</u></i> multiple selector you can configure the distance algorithm which is needed for the calculation; In the <i><u>k-string length</u></i> field you can configure the interval information for k-string length; In the <i><u>Markov model</u></i> field you can configure the interval information for Markov model; In the <i><u>Tree Constrcution Method</u></i> field you can configure the clustering algorithm (UPGMA or NJ).

### 1.3. Status bar

- After importing and configuring the sequences, you can click <i><u>Generate</u></i> button to start running the software. The running progress can be seen in this area.

### 1.4. Output panel

- After the calculation is complete, the obtained tree is presented on the <i><u>Output panel</u></i> from the software. We can select dto review different results and styles of trees (Standard and Circular). Meanwhile, by right clicking on the output image you can choose <i><u>Save</u></i> or <i><u>Save All ...</u></i> to output the results (bmp image, tree description file or distance matrix) or all plots respectively. Double-click the image, outputs can be reviewed separately in a pop-up box.

- For example, we input the comparison sequence in the <i><u>Iutput sequences</u></i> and run as follows, which allows us to output the evolutionary tree directly.

![image2](images/image2.png)

<center>Fig. 3. Running an example of <i>Ksak</i>.</center>

## 2. Advantages of <i>Ksak</i>

- Multi-window view: Multiple windows can be opened for easy comparison from tree to tree.

- Fully functional: <i>Ksak</i> allows you to produce plots, mark colors, and set fonts with one click.

- Language support: Chinese & English.

## 3. Features of <i>Ksak</i>

- The software is roughly divided into three panels. The left column is used to input sequences. You can clear the input sequence by clicking the Clear button; Import the sequence file by opening the input dialog box as shown in the figure by clicking the <i><u>Add</u></i> button. Meanwhile, the <i><u>Input</u></i> box supports file/folder drag-and-drop operation and will automatically apply the fasta format file in the folder to import. Double-click the sequence file name you can review the sequence information.

![image3](images/image3.png)

<center>Fig. 4. Import operation of <i>Ksak</i>.</center>

&nbsp;

- In addition, right click on the sequence name in the shortcut menu, you can mark the sequence with selected color. In this way, the sequences are color-categorized before comparison, and the output evolution tree is very clear.

![image4](images/image4.png)

<center>Fig. 5. Color setting of <i>Ksak</i>.</center>

&nbsp;

- <i>Ksak</i> can output two types of clustering tree, including UPGMA clustering and NJ clustering. The following figures show the output results of them.

![image5](images/image5.png)

<center>Fig. 6. UPGMA clustering</center>

&nbsp;

![image6](images/image6.png)

<center>Fig. 7. NJ clustering</center>

&nbsp;

- The output of <i>Ksak</i> can be saved in three ways. The first way is in image form, and you can output all the plots from all parameters at once and save them in a folder. The second way is in matrix form, where all the plots from all parameters are saved in matrix form, stored in the same folder, and saved in the parameter format. The third way is in notepad form, where all sequences are output in the format described under different parameters. These three ways are shown in the figures.

![image7](images/image7.png)

<center>Fig. 8. Three output ways of <i>Ksak</i>.</center>

&nbsp;

- For the output results in the form of evolution trees, we can upgrade the output to the following 7 presentation forms. The evolution tree allows us to visualize the different clustering effects and the clustering effect of species.

![image8](images/1.png)

<center>Fig. 9. Standard form.</center>

&nbsp;

![image9](images/2.png)

<center>Fig. 10. Circular form.</center>

&nbsp;

![image10](images/3.png)

<center>Fig. 11. Align text form.</center>

&nbsp;

![image11](images/4.png)

<center>Fig. 12. Triangular form.</center>

&nbsp;

![image12](images/5.png)

<center>Fig. 13. Bezier form.</center>

&nbsp;

![image13](images/6.png)

<center>Fig. 14. Circular triangular form.</center>

&nbsp;

![image14](images/7.png)

<center>Fig. 15. Circular bezier form.</center>

## Reference:

Liu, X. M., Wan, L., et al. (2011) New powerful statistics for alignment-free sequence comparison under a pattern transfer model. J. Theor. Biol, 284(1), 106-116.

Song, K., Ren, J., et al. (2013) Alignment-Free Sequence Comparison Based on Next-Generation Sequencing Reads. J Comp. Biol, 20, 64–79.

Liu, X. M., Huang, G. D., et al. (2019) Application of Sequence Alignment-Free Comparison-Based SeqDistK to Microbial Flora Clustering. J South Chin Norm Univ: Nat Sci Ed, 47(11), 71-77.

***
# <b>Contact & Support:</b>

- Li C. Xia: email: lcxia@scut.edu.cn

- Xuemei Liu: email: liuxm@scut.edu.cn

- Ziqi Cheng: email: php@mail.scut.edu.cn
