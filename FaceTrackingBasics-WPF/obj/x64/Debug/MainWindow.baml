   M S B A M L   `   `   `  ����Q  MFaceTrackingBasics-WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FaceTrackingBasicsFaceTrackingBasics  5   	   #    FaceTrackingBasics.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FaceTrackingBasics     5   	   -   5          �Name$  borde��5   	   $	��535��5	   	   $	��770��6    � WindowStartupLocation$ Manual=�6"    � WindowStyle$
 None=�6A    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush��%�   &	        &	 #     &	 F     �� 5   
   $ 	#ff6e6e6e��62   �� 5   
   $ 	#ff52318f��64   �� 5   
   $ 	#ff00BCF2��62   5      .��5      � -   5        $��
layoutGrid��5      $��10,0,10.2,76.6q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��0,0,-11,20.2q�6!   $
��Left=�67   $	��754��6R   .+�5      �� $
��Left=�6   $��Images\Logo.png��6*   $
��Fill=�6C   $��32��6R   $��81��6^   $��	0,0,0,5.2q�6i   $��Bottom=�6|   �� 5      $��1��6   $��Images\Status.png��6$   $
��None=�6?   $��Center=�6N   $��	280 0 0 5q�6k   $��RightToLeft=�6~   �� 5      -   5        $��Right=�5      $��40��6,   $��60��69   
������ 
������ $��0q�6w    � Cursor$
 Hand��6�   $��	290 0 0 5q�6�   .��5      �� .+�5      �� $��2��6   $��Images\sair1.png��6,   $��32��6F   $��RightToLeft=�6R   $��0,0,0,52q�6n    � FocusVisualStyle 5      �� 5      5!      5"      5#      5$      (� 5%   
    (� Stretch$ Uniform=�6   $��Center=�6$   $��0,67,62,-0.2q�6A   $��2��6W   $	��681��6h   .��5&      � -   5        $��MainGrid��5&      $
��1538��6#   $	��775��60   .+�5'      �� -   5        $��
ColorImage��5'      $��0,0,0,79q�6*   +   %FaceTrackingBasics.FaceTrackingViewer  5(      -   5        	  Name$	 faceTrackingViewer��5(   +   $��	0,0,0,100q�6G   5)      5+      �� 5-   
   -   5        $��ButtonIniciar��5-      $��Iniciar��6'   $
��Left=�69   $��38��6T   $��603,400.8,0,-64.2q�6`   $��1��6{   $	��Top=�6�   $	��134��6�   ���	#FFFAF9F9$��Center=�6�   $��1q�6�   ���	#FF63C6EB4  .System.Windows.Automation.AutomationProperties
   Name$
 
btnIniciar��6*   � BindingGroup 5.      &   System.Windows.Data.BindingGroup  5/      51      �� 52   
   -   5        $��ButtonListar��52      $��Edição��6&   $��38��68   $��431,400.8,187,-64.2q�6D   $��1��6a   $	��Top=�6n   ���	#FFFAF9F9$��Center=�6�   $��1q�6�   ���	#FF63C6EB$
 	btnListar��6   53        54      56      59      5:      