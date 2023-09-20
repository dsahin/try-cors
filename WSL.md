### Accessing a WSL 2 distribution from your local area network (LAN)

https://learn.microsoft.com/en-us/windows/wsl/networking#accessing-a-wsl-2-distribution-from-your-local-area-network-lan

```console
netsh interface portproxy add v4tov4 listenport=4000 listenaddress=0.0.0.0 connectport=4000 connectaddress=192.168.0.248
```


### How to find WSL2 machine's IP address from windows

https://superuser.com/questions/1586386/how-to-find-wsl2-machines-ip-address-from-windows

For checking your WSL IP address from the host machine:

```commmand
wsl -- ip -o -4 -json addr list eth0 `
| ConvertFrom-Json `
| %{ $_.addr_info.local } `
| ?{ $_ }
```

For checking your WSL IP address from the WSL machine:
```shell
ip addr show eth0 | grep -oP '(?<=inet\s)\d+(\.\d+){3}'
```