   M S B A M L   `   `   `  ����Q  MFaceTrackingBasics-WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FaceTrackingBasicsFaceTrackingBasics  5   	   !    FaceTrackingBasics.Auxiliar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FaceTrackingBasics     5   	     � Title$  Auxiliar��5   	   $	��535��6   $	��770��6'    � WindowStartupLocation$ CenterScreen=�63    � 	Resources 5	         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush �� 
TargetType �� Property �� Value��%�   &	        &	 #     &	 F     '�� i     �� 5
   
   $ 	#ff6e6e6e��62   �� 5   
   $ 	#ff52318f��64   �� 5   
   $ 	#ff00BCF2��62   �� 5   
   " ��6   .�5      ��  �@J�SnapsToDevicePixels . 64   5      5      .��5      � -   5        $��
layoutGrid��5      $��10,0,10.2,76.6q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��0 0 0 20q�6!   .+�5      �� $
��Left=�6   $��Images\Logo.png��6*   $
��Fill=�6C   $��32��6R   $��81��6^   $��0 10 0 5q�6i   �� 5      $��Right=�6   $��0 0 -1 0q�6/   $��Bottom=�6A   #��[  6\   $��Segoe UI)�6�   $��18(�6�   Face Tracking Basics6�   �� 5      $��1��6   $��Images\Status.png��6$   $
��None=�6?   $��Center=�6N   $��0 0 0 5q�6k   5      (� 5   
    (� Stretch$ Uniform=�6   $��Center=�6$   $��0,67,0.2,10q�6A   $��2��6V   .��5      � -   5        $��MainGrid��5      $	��640��6#   $	��480��6/   .+�5      �� -   5        $��
ColorImage��5      +   %FaceTrackingBasics.FaceTrackingViewer  5      -   5        	  Name$	 faceTrackingViewer��5   +   � 5!      -   5        
 �Name$
 
LayoutRoot��5!      ���	#000000005$      5%      5&      �� 5'   
   -   5        $��Iniciar��5'      $
��Left=�6#   $��38��6>   $��584,389,0,-67q�6J   $��1��6a   $	��Top=�6n   $	��134��6�   6�   �� 5(   
   -   5        $��Button��5(      $
��Left=�6"   $��38��6=   $��314,389,0,-67q�6I   $��1��6`   $	��Top=�6m   $	��137��6�   6�   5+      5,      