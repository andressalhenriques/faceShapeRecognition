   M S B A M L   `   `   `  ���� Q  MFaceTrackingBasics-WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FaceTrackingBasicsFaceTrackingBasics  !    FaceTrackingBasics.Auxiliar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:FaceTrackingBasics       � Title$  Auxiliar��$	��535��$	��770�� � WindowStartupLocation$ CenterScreen=� � 	Resources    MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush �� 
TargetType �� Property �� Value��%�   &	        &	      &	 *     '�� ?     �� $ 	#ff6e6e6e���� $ 	#ff52318f���� $ 	#ff00BCF2���� " ��.���  �@J�SnapsToDevicePixels . .��� -   $��
layoutGrid��$��10,0,10.2,76.6q� � RowDefinitions �� $
��Auto ��� $��* �.+�]� $��0��$��0 0 0 20q�.+��� $
��Left=�$��Images\Logo.png��$
��Fill=�$��32��$��81��$��0 10 0 5q��� $��Right=�$��0 0 -1 0q�$��Bottom=�#��[  $��Segoe UI)�$��18(�Face Tracking Basics�� $��1��$��Images\Status.png��$
��None=�$��Center=�$��0 0 0 5q�(�  (� Stretch$ Uniform=�$��Center=�$��0,67,0.2,10q�$��2��.��� -   $��MainGrid��$	��640��$	��480��.+��� -   $��
ColorImage��+   %FaceTrackingBasics.FaceTrackingViewer  -   	  Name$	 faceTrackingViewer��� -   
 �Name$
 
LayoutRoot�����	#00000000�� -   $��Iniciar��$
��Left=�$��38��$��584,389,0,-67q�$��1��$	��Top=�$	��134���� -   $��Button��$
��Left=�$��38��$��314,389,0,-67q�$��1��$	��Top=�$	��137��