This project may need some permissions before it's fully functional

Export information issues

1) Right click on the C: and select "Properties"

2) Select the "Security" tab

3) Make sure "Users" has full control


Event logging issues

1) Open the Registry Editor:
     Select Start then Run
     Enter regedit

2) Navigate/expand to the following key:
HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Eventlog

3) Right click on this entry and select Permissions

4) Add the "Users" user

    Give it Full control
