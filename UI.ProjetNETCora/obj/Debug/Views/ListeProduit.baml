   M S B A M L   `   `   `  ����K  GUI.ProjetNETCora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:UI.ProjetNETCora.ViewsUI.ProjetNETCora.Views  5      )    #UI.ProjetNETCora.Views.ListeProduit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3my$clr-namespace:UI.ProjetNETCora.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6    .��6.   Filtre sur le Libelle :6G   �� 5   
   $��0��6   $��0��6"   $��0, 20, 20, 20q�6/    �� TextWrapping$
 Wrap=�6F   ��6Z   �� *FiltreProduits+6}   �� 5   
   $��1��6   $��0��6!   $��0, 20, 125, 20q�6.   $
��10px(�6F   
����� ���6V   �� *BtnRechercheProduit+.��6�   
Rechercher6�   �� 5   
   $��2��6   $��0��6!   $��80, 20, 0, 20q�6.   $
��12px(�6E   
����� ���6U   �� *OpenWindowAddProduit+.��6�   Ajouter un produit6�   �� 5   
   $��0��6   $��1��6$   $��4��61   $	��5pxq�6B   ��6O   �� *
Produits+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedProduit+$ PropertyChanged=� �� Mode$ TwoWay=� �� View 5      �� 5      .P�5       ��  �� Width$
 50px��6%   $
��Code��62    �� DisplayMemberBinding 6@   �� *Code+�� 5!      $ 160px��6%   $��Libelle��63    6D   �� *	Libelle+�� 5"      $
 50px��6%   $��Stock��62    6A   �� *Stock+5#      5%      � 5&   
   $��0��6   $��6��6    5'      �� 5(      6)   �� 5)      6%   .+�5+      �� $��0��6   $��0, 15, 10, 15q�6%   $
��10px(�6<   
����� ���6L   �� *UpdateProduits+.��6�   
Rafraichir6�   �� 5,      $��1��6   $��0, 15, 10, 15q�6%   $
��10px(�6<   
����� ���6L   �� *DeleteProduits+.��6�   Supprimer selection6�   5-      *   $UI.ProjetNETCora.Views.DetailProduit  5/   
   $��1��6   $��1��6+   $��2��68   $��5��6L   	 � DataContext	 6]   �� *SelectedProduit+$ PropertyChanged=�6�   50      51      