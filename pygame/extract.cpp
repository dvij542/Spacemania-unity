#include "opencv2/opencv.hpp"
//#include "opencv2/core/core.hpp"
//#include "opencv2/imgproc/imgproc.hpp"
#include <math.h>
#include <iostream>
#include <queue>


using namespace cv;
using namespace std;

int main() {
	Mat img = imread("pacman-map.png",1);
	
	cout << "Food : " << (int)img.at<Vec3b>(25,24)[0] << " " << (int)img.at<Vec3b>(25,23)[1] << " " << (int)img.at<Vec3b>(25,23)[2]<<endl;
	cout << "Plain : " << (int)img.at<Vec3b>(16,16)[0] << " " << (int)img.at<Vec3b>(16,16)[1] << " " << (int)img.at<Vec3b>(16,16)[2]<<endl;
	Mat image(31,30,CV_8UC1,Scalar(0));
	for(int i1=25;i1<480;i1+=16){
		for(int i2=23;i2<430;i2+=16){
			bool allowed1 = false,allowed2 = true;
			for(int j=i1-8;j<i1+8;j++){
				for(int k=i2-8;k<i2+8;k++){
					if((int)img.at<Vec3b>(j,k)[0]==151&&(int)img.at<Vec3b>(j,k)[1]==184&&img.at<Vec3b>(j,k)[2]==255) allowed1=true;
					if(!(int)img.at<Vec3b>(j,k)[0]==0||!(int)img.at<Vec3b>(j,k)[1]==0||!(int)img.at<Vec3b>(j,k)[2]==0) allowed2 = false;
				}
			}
			if(allowed1||allowed2) image.at<uchar>((i1-9)/16,(i2-7)/16) = 255;
			else image.at<uchar>((i1-9)/16,(i2-7)/16) = 0; 
			if(allowed2){
				rectangle(img,Point(i2,i1),Point(i2+3,i1+3),Scalar(151,184,255),-1,8,0);
			}		}
	}
	namedWindow("derived",WINDOW_NORMAL);
	namedWindow("original",WINDOW_NORMAL);
	cout << "[" ;
	for(int i=0;i<31;i++){
		cout << "[";
		for(int j=0;j<27;j++){
			cout << ((int)image.at<uchar>(i,j)==255) <<",";
		}
		cout << 0 << "] ," << endl;
	}
	cout << "]"<<endl;
	imshow("original",img);
	imwrite("pacman-map.png",img);
	imshow("derived",image);
	waitKey(0);
	return 0;
}