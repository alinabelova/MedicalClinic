   M S B A M L   `   `   `  ����D  @Mita.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD0clr-namespace:Mita.Mvvm.Views;assembly=Mita.MvvmMita.Mvvm.Views  5      [ WMedicalClinic.PayDesk.ViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:MedicalClinic.PayDesk.ViewModels;assembly=MedicalClinic.PayDesk.ViewModels MedicalClinic.PayDesk.ViewModels 5       MedicalClinic.PayDesk%   MedicalClinic.PayDesk.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F	mitaViews0clr-namespace:Mita.Mvvm.Views;assembly=Mita.Mvvm     5      pviewModels1Xclr-namespace:MedicalClinic.PayDesk.ViewModels;assembly=MedicalClinic.PayDesk.ViewModels     5      (   "Mita.Mvvm.Views.ChildViewPresenter    ViewResizeMode$  CanMinimize=�5      {�5      �� *IsFree+.��5      � $��50,30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6$   $��Login��61   �� 5   
   $��0��6   $��1��6$   $��Password��61   �� 5   
   $��1��6   $��0��6"   $	��200��6k   $��	10,0,0,10q�5      ��5   /   �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��1��6   $��1��6"   $��	10,0,0,10q�5      ��5   /   �� *
Password+$ PropertyChanged=�5      �� 5!   
   $��2��6   $��2��6!   $��0��65   
���  ��$
��Bold"�5"   C   ��6   �� *ErrorMessage+6C   �� 5$   
   $��1��6   $��3��6!   $��Close��6.    �� IsCancel .  J� Opacity$ 0Q�6o   ��.  ��6>   �� *CloseCommand+6{   �� 5%   
   $��1��6   $��3��6!   $��Login��6.    �� 	IsDefault . $��	10,10,0,0q�6p   ��6>   �� *LoginCommand+6p   5&      5'      