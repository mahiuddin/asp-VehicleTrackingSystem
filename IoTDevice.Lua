wifi.setmode(wifi.STATION)

station_cfg={}
station_cfg.ssid="mahiMobileWifi" -- mahis_2.4G@unifi  mahiMobileWifi, umairTMRouter
station_cfg.pwd="mahi1234"   -- mahi1a2b3c  mahi1234 Multimedia123 fV9K70cMgT
station_cfg.save=false
wifi.sta.config(station_cfg)

mytimer = tmr.create()
--print(mytimer:state()) -- nil
mytimer:register(5000, tmr.ALARM_SINGLE, function() 
   if wifi.sta.getip() == nil then
      print("Connecting to AP...\n")
   else
      ip, nm, gw=wifi.sta.getip()
      print("IP Info: \nIP Address: ",ip)
      print("Netmask: ",nm)
      print("Gateway Addr: ",gw,'\n')
      mytimer:stop()            
   end 
end)
mytimer:start()

-- close the time when wifi connected

-- getting the temparature
Vref = 3.0 -- its default value is 3.3 but for the error of nodemcu i set it 3.0 to get correct result 
resolution = Vref/1023

postTimer = tmr.create()

postTimer:register(60000, tmr.ALARM_AUTO, function()
    analogVtg = adc.read(0)
    if analogVtg> 1023 then
    analogVtg = 1023
    end
    temperature = (analogVtg * resolution)*100
    print('LM35 Temperature:', temperature)
    -- a simple http server 
    http.post('https://localhost:44323/api/VehicleLocation/',
      'Content-Type: application/json\r\n',
      '{"Latitude": 96.35,
    "Longitude": 26.35,
    "Altitute": 56.34,
    "HorizontalAccuracy": 25.36,
    "VerticalAccuracy": 56.35,
    "Speed":54.36,
    "VehicleId": 1}',
      function(code, data)
        if (code < 0) then
          print("HTTP request failed")
        else
          print(code, data)
        end
      end)

end)
postTimer:start()