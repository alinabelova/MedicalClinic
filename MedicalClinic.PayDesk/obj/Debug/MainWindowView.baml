   M S B A M L   `   `   `  ����D  @Mita.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD0clr-namespace:Mita.Mvvm.Views;assembly=Mita.MvvmMita.Mvvm.Views  5      [ WMedicalClinic.PayDesk.ViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:MedicalClinic.PayDesk.ViewModels;assembly=MedicalClinic.PayDesk.ViewModels MedicalClinic.PayDesk.ViewModels 5       MedicalClinic.PayDesk*   $MedicalClinic.PayDesk.MainWindowView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F	mitaViews0clr-namespace:Mita.Mvvm.Views;assembly=Mita.Mvvm     5      pviewModels1Xclr-namespace:MedicalClinic.PayDesk.ViewModels;assembly=MedicalClinic.PayDesk.ViewModels     5      (   "Mita.Mvvm.Views.ChildViewPresenter    ViewResizeMode$  CanMinimize=�5      {�5      �� *IsFree+.��5      ]� .+�5   
   �� $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $
��5,10q�6C    � 	Resources 5      ��%    5      .+�5      �� $��25��6   $��1.png��6   $y�Visible=�6.   $	��5,0q�6C   6S   �� 5      $5��/Электронная регистратура��6   5      � 5   
   $��50, 0, 50, 30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   .+�5!   
   �� $��0��6   $��0��6!   $'��!Расписание врачей��6.    �� 	IsDefault . $��0,10,0,0q�6|   ��6J   �� *TableCommand+6|   �� 5"   
   $��0��6   $��1��6!   $!��Платные услуги��6.    . $��0,10,0,0q�6y   ��6G   �� *PriceCommand+6y   �� 5#   
   $��0��6   $��2��6!   $*��$Записаться на приём��6.    . $��0,10,0,0q�6~   ��6L   �� *TalonCommand+6~   5$      5%      5&      