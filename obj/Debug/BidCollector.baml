   M S B A M L   `   `   `  ����I  ETarneebSandbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TarneebTarneeb  5   	       Tarneeb.BidCollector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Tarneeb     5   	     � Title$	  Bid��5	   	   $	��350��6   $	��200��6"   .��5
      � .+�5   
   �� .+�5      �� $��Please enter your bid��6   �� 5      -   5         ��Name$ bidNum��5      $��Right=�6�   $��40��6�   ��6$   ��  �� ElementName$ slideBidVal�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5         ��Name$ slideBidVal��5       � Minimum$ 7Q�6*    � Maximum$ 13Q�66    �� TickPlacement$ BottomRight=�6C   	 �� IsSnapToTickEnabled	 . 
 �� TickFrequency$
 1Q�6z   $��	0,0,10,10q�6�   �� 5      -   5         ��Name$ bidSuit��5      $��
10,10,10,5q�6(   .��5      �� .+�5      	� -   5        $��rHearts��5   "   $��Hearts��61    d� 	IsChecked$
 TrueY�6B   $��
10,10,10,0q�6S   	� 5      -   5        $��rClubs��5   "   $��Clubs��60   $��
10,10,10,5q�6@   	� 5      -   5        $��	rDiamonds��5   "   $��Diamonds��63   $��
10,10,10,5q�6F   	� 5      -   5        $��rSpades��5   "   $��Spades��61   $��
10,10,10,5q�6B   5      5      �� 5      -   5        $��btnBid��5      $��50��6#   $	��Bid��6.   $��Center=�6<   $��
10,10,10,5q�6n   5      5      5       