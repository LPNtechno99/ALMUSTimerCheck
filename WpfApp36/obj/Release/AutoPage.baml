   M S B A M L   `   `   `  ���� C  ?WpfApp36, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp36WpfApp36      WpfApp36.AutoPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:WpfApp36       N� 
Background
  ����� N� Title$ AutoPage�� � 	Resources    WpfApp36.GreenCoverter   GreenCoverter   WpfApp36.YelloConverter  YelloConverter��%   &	        &	          .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��  � ColumnDefinitions �� $
��0.3* ��� $��* ��� $
��0.5* �.+��� 
���   �$��1q�._��� $��imege/anh.png���� -   $��TbAuto��$��1���� 
���   �$��1q�$��1��._��� $��PRODUCTION COUNTER��$��55(� �� TextAlignment$ Center=�$��Center=�$��Center=�� $��2�� �� $
��Auto ��� $
��Auto �.+�� 
�������.+��� 
���   �$��1q�._��� $��Model��$��40(�$��Center=�$��Center=��� 
���   �$��1q�$��1��._��� -   $��TblModel��$��40(�$��Center=�$��Center=�� $��1�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��2��
�������.+��� 
���   �$��1q�._��� $��Leader��$��51(�$��SemiBold"�$��Center=�$��Center=��� 
���   �$��1q�$��3��._��� -   $��	TblLeader��$��51(�$��Center=�$��Center=�� $��0��
�������.+��� 
���   �$��1q�._��� $
��Line��$��51(�$��SemiBold"�$��Center=�$��Center=��� 
���   �$��1q�$��1��._��� -   $��TblLine��$��51(�$��Center=�$��Center=�� $��4��
�������.+��� 
���   �$��1q�$��4��._��� $��Worker��$��51(�$��SemiBold"�$��Center=�$��Center=��� 
���   �$��1q�$��5��._��� -   $��	TblWorker��$��51(�$��Center=�$��Center=�� $��2�� �� $��* ��� $��* ��� $��* �.+��� 
���   �$��1q�._��� $��Product Count��$��51(�$��Center=�$��Center=��� 
���   �$��1q�$��1��._��� $��Target��$��Center=�$��51(�$��Center=��� 
���   �$��1q�$��2��._��� -   $��	TblTarget��$
��Text��$��51(�$��Center=�$ Center=�� $��3�� �� $��* ��� $��* ��� $��* ��� $��* �.+��� 
���   �$��1q�._��� $
��Time��$��51(�$ Center=�$��Center=��� 
���   �$��1q�$��1��._��� $��Result��$��51(�$ Center=�$��Center=��� 
���   �$��1q�$��2��._��� $
��Tact��$��51(�$ Center=�$��Center=��� 
���   �$��1q�$��3��._��� $��Compare��$��51(�$ Center=�$��Center=��� -   $��LvMain��$��4������ .R��  �� $��* ��� $��* ��� $��* ��� $��* �.+�� ���� *Mausac+ �� 	Converter# [ .+��� 
���   �$��1q�._��� $��51(�$��SemiBold"�$��Center=�$��Center=����� *
LineName+� $��
GridThucTe��-   $��1������ *Mausac+# [ .+��� 
���   �$��1q�$��1��._��� $	��200��$��51(�$ Center=����� *SanLuongThucTe+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	 �� StringFormat$		 0,0��� $��	GridTutao��-	   $��2������ *Mausac+# [ .+��� 
���   �$��1q�$��2��._��� $	��200��$��51(�$ Center=����� *SanLuongTuTao+$		 0,0��� $��3������ *SanLuongChenh+# [  .+��� 
���   �$��1q�$��3��._��� $ Center=�$	��200��$��51(����� *SanLuongChenh+$		 0,0��