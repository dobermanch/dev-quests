# Networking

---

## 🧱 OSI Model: The 7 Networking Layers

| Layer | Name         | Function Summary                                 |
|-------|-------------|--------------------------------------------------|
| 7     | Application | Interfaces with user apps (e.g., HTTP, SMTP)     |
| 6     | Presentation| Data formatting, encryption, compression         |
| 5     | Session     | Manages sessions between systems                 |
| 4     | Transport   | Reliable delivery (TCP/UDP, segmentation)        |
| 3     | Network     | Routing and addressing (IP)                      |
| 2     | Data Link   | MAC addressing, error detection                  |
| 1     | Physical    | Bits over cables, radio, fiber                   |

Each layer serves the one above it and is served by the one below. It’s a powerful abstraction for troubleshooting, protocol design, and understanding how data flows across networks.

---

## 🔗 Transmission Control Protocol (TCP)

### 🧱 Core Characteristics

- **Connection-Oriented:** TCP establishes a session using a 3-way handshake (SYN → SYN-ACK → ACK) before data transfer begins.
- **Reliable Delivery:** Ensures all packets arrive in order and without corruption using sequence numbers, acknowledgments, and retransmissions.
- **Byte Stream Abstraction:** TCP treats data as a continuous stream of bytes, not discrete messages.
- **Full Duplex:** Supports simultaneous bidirectional communication.

### 📦 TCP Segment Structure

| Field                   | Purpose                        |
|-------------------------|-------------------------------|
| Source/Destination Port | Identifies endpoints          |
| Sequence Number         | Tracks byte order             |
| Acknowledgment Number   | Confirms receipt              |
| Flags (SYN, ACK, FIN)   | Controls connection state     |
| Window Size             | Enables flow control          |
| Checksum                | Validates integrity           |

### 🔄 Connection Lifecycle

- **Establishment:** 3-way handshake synchronizes sequence numbers.
- **Data Transfer:** Segments are acknowledged; retransmissions occur if ACKs are delayed.
- **Termination:** 4-step FIN/ACK exchange gracefully closes the session.

### 📉 Congestion & Flow Control

- **Sliding Window Protocol:** Controls how much data can be sent before waiting for ACK.
- **Congestion Control Algorithms:**
  - Slow Start: Begins cautiously, then ramps up.
  - Congestion Avoidance: Adjusts window size based on network feedback.
  - Fast Retransmit & Recovery: Quickly handles packet loss without full restart.

### 🔐 TCP in Secure & Scalable Systems

- **TLS over TCP:** Encrypts data in transit — essential for secure APIs and services.
- **Proxy & Load Balancer Compatibility:** TCP works seamlessly with reverse proxies and L4/L7 load balancers.
- **Keep-Alive & Idle Timeout:** Important for long-lived connections in microservices.

---

## 🚀 User Datagram Protocol (UDP)

### 🧱 Core Characteristics

- **Connectionless:** No handshake or session setup — packets are sent without prior coordination.
- **Unreliable by Design:** No guarantees of delivery, order, or duplication protection. If reliability is needed, it must be handled at the application layer.
- **Lightweight:** Just an 8-byte header — minimal overhead compared to TCP’s 20–60 bytes.
- **Fast & Efficient:** Ideal for time-sensitive applications where latency matters more than accuracy.

### 📦 UDP Datagram Structure

| Field            | Size     | Purpose                        |
|------------------|----------|-------------------------------|
| Source Port      | 16 bits  | Identifies sender’s port       |
| Destination Port | 16 bits  | Identifies receiver’s port     |
| Length           | 16 bits  | Total length of header + data  |
| Checksum         | 16 bits  | Optional in IPv4, mandatory in IPv6 |

### 🎯 Common Use Cases

- DNS Queries
- VoIP & Video Streaming
- Online Gaming
- DHCP
- Multicast/Broadcast

### ⚠️ Trade-offs & Considerations

- No Congestion Control
- No Retransmission
- Security Risks (spoofing, DDoS)

### 🧠 UDP vs TCP — Quick Comparison

| Feature            | TCP                        | UDP                        |
|--------------------|---------------------------|----------------------------|
| Connection Setup   | Yes (3-way handshake)     | No                         |
| Reliability        | Guaranteed delivery/order | No guarantees              |
| Speed              | Slower (more overhead)    | Faster, minimal overhead   |
| Use Cases          | Web, email, file transfer | Streaming, gaming, DNS     |
| Header Size        | 20–60 bytes               | 8 bytes                    |

### 📡 UDP Unicast

- **One-to-one communication:** A single sender transmits data to a single receiver.
- **Direct addressing:** Uses the recipient’s IP and port.
- **Use case:** Web requests, file transfers, API calls.

### 🌐 UDP Multicast

- **One-to-many communication:** Sender transmits data to a group of receivers (multicast group).
- **Uses multicast IP addresses:** 224.0.0.0 to 239.255.255.255.
- **Use case:** Streaming media, real-time telemetry, online gaming, IoT broadcasts.

### 🔄 Comparison Table

| Feature              | UDP Unicast      | UDP Multicast         |
|----------------------|------------------|-----------------------|
| Communication Model  | One-to-one       | One-to-many           |
| IP Addressing        | Specific IP      | Multicast group IP    |
| Bandwidth Efficiency | Low              | High                  |
| Router Support       | Universal        | Requires multicast    |
| Use Cases            | DNS, API calls   | Video streaming, sensors |
| Protocols Involved   | UDP              | UDP + IGMP            |

---

## 🔐 What Is TLS?

TLS is a cryptographic protocol that ensures:

- **Confidentiality:** Data is encrypted.
- **Integrity:** Data can't be tampered with undetected.
- **Authentication:** Verifies the identity of the server (and optionally the client).

### 🧱 TLS Protocol Layers

- **Handshake Protocol:** Negotiates cipher suites, authenticates parties, and establishes session keys.
- **Record Protocol:** Encrypts and transmits data.
- **Alert Protocol:** Communicates errors or warnings.
- **Change Cipher Spec Protocol:** Signals when encryption settings change.

### 🤝 TLS Handshake — Step-by-Step

1. **TCP Connection Initiation:** 3-way handshake.
2. **ClientHello:** Client sends supported TLS versions, cipher suites, random number, and extensions.
3. **ServerHello:** Server chooses cipher suite, sends certificate, random number, and extensions.
4. **Authentication & Certificate Verification:** Client verifies server’s certificate.
5. **Key Exchange:** Client and server agree on a shared secret.
6. **Session Key Derivation:** Both sides derive symmetric keys.
7. **Change Cipher Spec & Finished Messages:** Both sides confirm handshake integrity.
8. **Secure Communication Begins:** All further data is encrypted.

### 🧠 TLS vs SSL

- SSL is deprecated; TLS 1.2/1.3 are current.
- TLS 1.3 is faster, more secure, and removes outdated algorithms.

### 🛡 TLS in Practice

- **HTTPS:** TLS + HTTP = secure web browsing.
- **TLS Certificates:** Issued by Certificate Authorities (CAs).
- **Forward Secrecy:** Ephemeral keys for session security.
- **Session Resumption:** Faster repeat connections.

---

## 🌐 What Is SNI?

**SNI (Server Name Indication)** is a TLS extension that allows a client to specify the hostname it wants to connect to during the ClientHello phase.

### 🧠 Why SNI Matters

- Enables multiple HTTPS websites to share a single IP address and port.
- Allows correct certificate selection.
- Reduces need for multiple IPs.

### 🔄 How SNI Works

1. ClientHello: Client includes desired hostname in SNI field.
2. ServerHello: Server selects appropriate certificate.
3. Certificate Presentation: Server sends matching certificate.
4. Handshake Completion: TLS handshake proceeds.

### 🔐 Limitations & Privacy

- SNI is not encrypted (can be observed).
- ECH (Encrypted Client Hello) is a newer proposal to address this.

---

## ⚡ What Is QUIC?

QUIC is a UDP-based transport protocol (RFC 9000) designed to:

- Reduce connection setup latency
- Improve multiplexing (no head-of-line blocking)
- Provide built-in encryption (TLS 1.3)
- Support connection migration

### 🔍 Key Features

| Feature                | Description                                 |
|------------------------|---------------------------------------------|
| UDP-based              | Avoids kernel ossification, user-space innovation |
| TLS 1.3 integration    | Security is built-in                        |
| Multiplexed streams    | Avoids TCP’s head-of-line blocking          |
| 0-RTT & 1-RTT setup    | Faster connection establishment             |
| Connection migration   | Seamless session continuation               |
| Congestion control     | User-space algorithms                       |

### 🔐 QUIC vs TCP + TLS

| Aspect             | TCP + TLS         | QUIC                |
|--------------------|-------------------|---------------------|
| Transport Layer    | TCP               | UDP                 |
| Encryption Setup   | Separate handshake| Integrated          |
| Multiplexing       | HOL blocking      | Independent streams |
| Connection Setup   | Multiple RTTs     | 0-RTT or 1-RTT      |
| Mobility Support   | Limited           | Built-in            |
| Extensibility      | Hard (kernel)     | Easy (user-space)   |

### 🌐 Real-World Adoption

- Browsers: Chrome, Firefox, Safari, Edge
- Platforms: Google, Cloudflare, Facebook, Microsoft
- Use Cases: Video streaming, gaming, VoIP, CDN, mobile apps

---

## 🌐 What Is DNS?

DNS is the "phonebook" of the internet, translating domain names to IP addresses.

### 🧭 How DNS Works

1. User types a domain.
2. Local cache check.
3. DNS resolver query.
4. Root server → TLD server → Authoritative server.
5. IP address returned to client.

### 🧱 DNS Components

| Component         | Role                                  |
|-------------------|---------------------------------------|
| DNS Resolver      | Initiates and manages the query       |
| Root Server       | Directs to TLD servers                |
| TLD Server        | Points to authoritative servers       |
| Authoritative Server | Holds actual DNS records           |

### 📦 Common DNS Record Types

- A, AAAA, CNAME, MX, TXT

### 🔐 DNS Security & Extensions

- DNSSEC, DoH, DoT, Reverse DNS

---

## 🌐 What Is NAT?

NAT (Network Address Translation) translates private IPs to public IPs, allowing multiple devices to share a single public IP.

### 🔄 How NAT Works

- Router replaces source IP with its own public IP.
- Tracks mapping in NAT table.
- Forwards responses to correct internal device.

### 🧱 Types of NAT

| Type         | Description                        | Use Case                  |
|--------------|------------------------------------|---------------------------|
| Static NAT   | One-to-one mapping                 | Hosting internal services |
| Dynamic NAT  | Pool of public IPs                 | Moderate traffic          |
| PAT (Overload)| Many-to-one using port numbers    | Homes, offices            |

### 🔐 NAT & Security

- Hides internal IPs, prevents unsolicited inbound traffic.

### 🧠 Advanced Concepts

- NAT Traversal (STUN, TURN, ICE), Hairpin NAT, NAT64

---

## 🔐 What Is IPsec?

IPsec is a suite of protocols that secures IP communications at the network layer.

### 🧱 Core Components

| Component | Purpose                                         |
|-----------|------------------------------------------------|
| AH        | Integrity/authentication, no encryption        |
| ESP       | Encryption, integrity, authentication          |
| IKE       | Negotiates keys and security associations      |

### 🔄 Modes of Operation

| Mode          | Description                                |
|---------------|--------------------------------------------|
| Transport     | Encrypts only the payload                  |
| Tunnel        | Encrypts the entire IP packet              |

### 🔁 IPsec Workflow

- IKE Phase 1: Secure channel setup
- IKE Phase 2: Tunnel parameters
- Data Transfer: ESP/AH
- Tunnel Termination

### 🧠 Use Cases

- VPNs, secure routing, IoT, cloud networking

---

## 🌐 What Is IP?

IP (Internet Protocol) routes and addresses data packets across networks.

### 🧱 IP Packet Structure

- Header: Source/destination IP, TTL, protocol, checksum
- Payload: Data

### 🧠 IP Addressing

| Version | Format  | Address Space         | Example           |
|---------|---------|----------------------|-------------------|
| IPv4    | 32-bit  | ~4.3 billion         | 192.168.1.1       |
| IPv6    | 128-bit | ~340 undecillion     | 2001:0db8::1      |

### 🔄 IP Routing

Routers use headers and routing tables to forward packets.

### 📦 Types of IP Communication

| Type      | Description                |
|-----------|---------------------------|
| Unicast   | One-to-one                |
| Broadcast | One-to-all (subnet)       |
| Multicast | One-to-many (group)       |
| Anycast   | One-to-nearest            |

### 🔐 IP & Security

- IPsec, NAT, firewalls

---

## 🔐 What Is a VPN?

A VPN (Virtual Private Network) creates a secure, encrypted tunnel between your device and a remote server.

### 🧱 Core Benefits

- Privacy, security, geo-unblocking, remote access

### 🧠 How It Works

1. Connect to VPN client
2. Secure handshake with server
3. VPN protocol establishes encryption/routing
4. Traffic is encrypted and tunneled
5. Server decrypts and forwards traffic

### 📦 Common VPN Protocols

| Protocol      | Speed    | Security      | Notes                       |
|---------------|----------|---------------|-----------------------------|
| OpenVPN       | Moderate | Very strong   | Highly configurable         |
| WireGuard     | Fast     | Strong        | Lightweight, modern         |
| IKEv2/IPsec   | Fast     | Strong        | Great for mobile            |
| L2TP/IPsec    | Moderate | Moderate      | Older, widely supported     |
| PPTP          | Fast     | Weak          | Deprecated                  |

### 🛠 VPN Types

- Remote Access, Site-to-Site, SSL VPN, Cloud VPN

### 🔍 Use Cases

- Corporate access, streaming, privacy, gaming

---

## 🧱 What Is a DMZ?

A DMZ (Demilitarized Zone) is a perimeter network that hosts public-facing services while isolating them from the internal LAN.

### 🔄 How a DMZ Works

- External traffic hits first firewall
- Routed to DMZ servers
- Second firewall restricts DMZ-to-LAN access

### 🧱 DMZ Architecture Models

| Model                | Description                                 |
|----------------------|---------------------------------------------|
| Single Firewall      | One firewall, three interfaces              |
| Dual Firewall        | Two firewalls (WAN-DMZ, DMZ-LAN)            |
| Cloud DMZ            | Virtualized with VPCs, security groups      |

### 📦 Typical DMZ Services

- Web, mail, DNS, FTP, proxies, VPN gateways

### 🔐 Security Benefits

- Segmentation, access control, reconnaissance prevention, compliance

---

## 🧭 What Is a Proxy Server?

A proxy server sits between your device and the internet, forwarding requests on your behalf.

### 🧱 Types of Proxy Servers

| Type              | Description                                         |
|-------------------|----------------------------------------------------|
| Forward Proxy     | Hides client identity, accesses external resources  |
| Reverse Proxy     | Hides origin server, handles incoming requests      |
| Transparent Proxy | No IP hiding, used for monitoring/caching           |
| Anonymous Proxy   | Hides client IP, identifies as proxy                |
| High Anonymity    | Hides both client IP and proxy identity             |
| Distorting Proxy  | Sends false IP to destination                       |
| CGI Proxy         | Web-based, accessed via browser forms               |
| Smart DNS Proxy   | Redirects DNS for location spoofing                 |

### 🔐 Common Use Cases

- Content filtering, caching, geo-unblocking, load balancing, security

### ⚠️ Proxy vs VPN

| Feature         | Proxy Server         | VPN                   |
|-----------------|---------------------|-----------------------|
| Encryption      | Usually none        | Strong encryption     |
| IP Masking      | Yes                 | Yes                   |
| Traffic Scope   | App-specific        | Entire device         |
| Performance     | Faster              | Slower (encryption)   |
| Privacy         | Moderate            | Strong                |

---

## 🔄 What Is a Reverse Proxy?

A reverse proxy receives client requests and forwards them to backend servers.

### 🧱 Key Functions

| Function         | Description                                  |
|------------------|----------------------------------------------|
| Load Balancing   | Distributes traffic across servers           |
| SSL Termination  | Handles TLS encryption/decryption            |
| Caching          | Stores content to reduce latency             |
| Security         | Blocks malicious traffic, hides server IPs   |
| Compression      | Reduces payload size                         |
| Routing          | Directs requests based on path, headers, etc.|

### 🛠 Common Tools

- NGINX, HAProxy, Envoy, Traefik, Cloudflare, AWS ALB

### 🧠 Use Cases

- Microservices, multi-region, zero-trust, API gateways

---

## ⚙️ What Is a Load Balancer?

A load balancer distributes incoming traffic across multiple servers.

### 🧠 How It Works

- Receives request
- Health checks backend servers
- Routes request based on algorithm
- Handles failover and session persistence

### 🧱 Types of Load Balancers

| Type                | Description                                 |
|---------------------|---------------------------------------------|
| Layer 4 (Transport) | Routes by IP/TCP/UDP                        |
| Layer 7 (App)       | Routes by HTTP headers, cookies, paths      |
| GSLB                | Routes across geographic regions            |
| Hardware LB         | Dedicated devices (F5, Citrix)              |
| Software LB         | Runs on VMs/containers (HAProxy, NGINX)     |
| Cloud LB            | Managed services (AWS ELB, Azure Front Door)|

### 🔄 Algorithms

| Algorithm           | Description                                 |
|---------------------|---------------------------------------------|
| Round Robin         | Cycles through servers                      |
| Least Connections   | Chooses server with fewest connections      |
| IP Hash             | Routes by client IP                         |
| Weighted Round Robin| Prioritizes higher-capacity servers         |
| Least Response Time | Chooses fastest server                      |

### 🚀 Benefits

- High availability, scalability, performance, security, cost efficiency

---

## 🔌 What Is a Socket?

A socket is an endpoint for sending or receiving data across a network.

### 🧱 Socket Components

| Component    | Description                        |
|--------------|------------------------------------|
| IP Address   | Identifies the host                |
| Port Number  | Identifies the service/application |
| Protocol     | TCP, UDP, etc.                     |
| Socket Addr  | IP + Port + Protocol               |

### 🔄 Types of Sockets

| Type           | Protocol | Characteristics                        |
|----------------|---------|-----------------------------------------|
| Stream Socket  | TCP     | Reliable, ordered, connection-oriented  |
| Datagram Socket| UDP     | Unreliable, unordered, connectionless   |
| Raw Socket     | IP      | Direct access to lower-level protocols  |

### 🛠 Common Operations

- socket(), bind(), listen(), connect(), accept(), send()/recv(), close()

### 🧠 Use Cases

- Web servers, DNS, messaging apps, IoT devices

---

## 🧭 What Is SOCKS?

SOCKS is a proxy protocol at the session layer (Layer 5) for secure, flexible routing of network traffic.

### 🧱 SOCKS Versions

| Version | Features                                   |
|---------|--------------------------------------------|
| SOCKS4  | TCP only, no authentication                |
| SOCKS4a | Adds domain name resolution                |
| SOCKS5  | TCP & UDP, authentication, IPv6, DNS fwd   |

### 🔄 How SOCKS5 Works

- Client connects to proxy (port 1080)
- Handshake and authentication
- Connection request (destination IP/port)
- Proxy relays traffic

### 🔐 Use Cases

- Bypassing firewalls, anonymity, secure tunneling, Tor

---

## 🔐 What Is SSH?

SSH (Secure Shell) is a protocol for secure remote access, automation, and encrypted communication.

### 🧱 SSH Architecture

| Layer             | Role                                      |
|-------------------|-------------------------------------------|
| Transport Layer   | Encryption, integrity, server auth        |
| User Auth Layer   | Verifies client identity                  |
| Connection Layer  | Multiplexes tunnel into channels          |

### 🔑 Authentication Methods

- Password, public key, certificate, keyboard-interactive

### 🛠 Common Use Cases

- Remote shell, file transfer (scp, sftp), port forwarding, SOCKS proxy, Git over SSH

### 🧠 SSH vs Telnet

| Feature      | Telnet | SSH         |
|--------------|--------|-------------|
| Encryption   | ❌     | ✅          |
| Auth         | Plain  | Public key  |
| Security     | Weak   | Strong      |
| Use Today    | No     | Yes         |

### 🔐 Key Management Tips

- Use passphrases, store keys securely, rotate regularly, use ssh-agent

---

## 🌐 What Is HTTP?

HTTP (Hypertext Transfer Protocol) is the backbone of web communication.

### 🔄 HTTP Request-Response Cycle

- Client sends request (method, URL, headers, body)
- Server processes and responds (status code, headers, body)

### 🧠 Common HTTP Methods

| Method   | Purpose              |
|----------|----------------------|
| GET      | Retrieve data        |
| POST     | Submit new data      |
| PUT      | Replace data         |
| PATCH    | Partially update     |
| DELETE   | Remove data          |
| OPTIONS  | Discover methods     |
| HEAD     | Headers only         |

### 📦 Key Headers

- Content-Type, Accept, Authorization, User-Agent, Cache-Control

### 📊 Status Codes

| Code Range | Meaning         |
|------------|----------------|
| 1xx        | Informational   |
| 2xx        | Success         |
| 3xx        | Redirection     |
| 4xx        | Client error    |
| 5xx        | Server error    |

### 🔐 HTTP vs HTTPS

- HTTP: Plaintext
- HTTPS: Encrypted via TLS

---

## 🚀 What Is HTTP/2?

HTTP/2 (RFC 7540) improves performance over HTTP/1.1.

### 🧠 Key Features

| Feature           | Description                                 |
|-------------------|---------------------------------------------|
| Binary framing    | Compact, efficient parsing                  |
| Multiplexing      | Multiple requests/responses per connection  |
| Header compression| HPACK reduces overhead                      |
| Stream prioritization | Assign weights/dependencies             |
| Server push       | Proactive resource delivery                 |
| Single connection | No need for multiple TCP connections        |

### 🔄 Performance Improvements

- Fixes application-layer head-of-line blocking
- Reduces round trips
- Improves bandwidth utilization

### 🔐 Encryption & Adoption

- All major browsers require HTTP/2 over TLS

### 🧬 HTTP/2 vs HTTP/1.1

| Aspect            | HTTP/1.1     | HTTP/2         |
|-------------------|--------------|----------------|
| Format            | Text         | Binary         |
| Connections       | Multiple     | Single         |
| Header compression| None         | HPACK          |
| Server push       | No           | Yes            |
| Prioritization    | No           | Yes            |
| Performance       | Limited      | Optimized      |

---

## 🚀 What Is HTTP/3?

HTTP/3 (RFC 9114) runs over QUIC (UDP), not TCP.

### 🔍 Why QUIC?

| Feature                | TCP (HTTP/1.1/2) | QUIC (HTTP/3)         |
|------------------------|------------------|-----------------------|
| Transport Layer        | TCP              | UDP + QUIC            |
| Connection Setup       | Multiple RTTs    | 0-RTT or 1-RTT        |
| Head-of-Line Blocking  | Yes              | No                    |
| Encryption             | TLS over TCP     | Built-in TLS 1.3      |
| Connection Migration   | Not supported    | Seamless              |
| Multiplexing           | HOL blocking     | Native stream isolation|

### 🧠 Key Features

- Multiplexed streams, header compression (QPACK), server push, built-in encryption, connection migration, 0-RTT

### 📊 Adoption

- Supported by all major browsers and CDNs
- Improves performance on mobile/high-latency networks

---

## 🕰️ What Is HTTP Long Polling?

Long polling is a technique for simulating real-time updates over HTTP.

### 🔄 How It Works

1. Client sends GET request.
2. Server holds connection until data or timeout.
3. Server responds.
4. Client immediately sends new request.

### ⚖️ Pros & Cons

| ✅ Pros                  | ❌ Cons                        |
|-------------------------|-------------------------------|
| Broad browser support   | High server resource usage    |
| Simple to implement     | Poor scalability              |
| Firewall-friendly       | Higher latency                |
| Reliable fallback       | Complex retry/timeout logic   |

### 🔁 Alternatives

1. **WebSockets:** Bidirectional, persistent, ideal for chat/gaming.
2. **Server-Sent Events (SSE):** One-way push, lightweight for streaming.
3. **HTTP Streaming:** Server streams data as available.
4. **MQTT:** Lightweight pub/sub for IoT.
5. **GraphQL Subscriptions:** Real-time GraphQL, uses WebSockets.

### 🧠 When to Use What?

| Use Case                  | Best Option             |
|---------------------------|-------------------------|
| Legacy browser support    | Long Polling            |
| Bidirectional chat/gaming | WebSockets              |
| Live scores/stock updates | SSE or Streaming        |
| IoT telemetry             | MQTT                    |
| Real-time GraphQL API     | GraphQL Subscriptions   |

---

## 🔄 What Are WebSockets?

WebSockets enable real-time, bidirectional communication over a single, persistent TCP connection.

### 🧱 WebSocket Lifecycle

- **Handshake:** HTTP request with `Upgrade: websocket`; server replies with `101 Switching Protocols`.
- **Connection Established:** TCP connection remains open.
- **Message Exchange:** Both sides send/receive asynchronously.
- **Closing Handshake:** Either side can initiate shutdown with a Close frame.

### 📦 WebSocket Frames

| Frame Type   | Purpose                      |
|--------------|-----------------------------|
| Text Frame   | UTF-8 encoded messages      |
| Binary Frame | Raw binary data             |
| Ping/Pong    | Keep-alive, latency checks  |
| Close Frame  | Initiates shutdown          |

Messages can be fragmented; control frames (Ping/Pong) are limited to 125 bytes.

### 🔐 Security & Protocols

- `ws://` — unencrypted
- `wss://` — encrypted via TLS
- Supports subprotocols (e.g., STOMP, MQTT) and extensions (e.g., compression)

### 🛠 WebSocket API (Browser Example)

```js
const socket = new WebSocket('wss://example.com/socket');

socket.onopen = () => socket.send('Hello Server!');
socket.onmessage = (event) => console.log('Received:', event.data);
socket.onclose = () => console.log('Connection closed');
socket.onerror = (err) => console.error('Error:', err);
```

### ⚖️ WebSockets vs HTTP

| Feature             | HTTP             | WebSockets         |
|---------------------|------------------|--------------------|
| Communication Model | Request-response | Bidirectional      |
| Connection          | Short-lived      | Persistent         |
| Latency             | Higher           | Lower              |
| Use Cases           | REST APIs, sites | Realtime apps      |

---

## Questions

### 🌐 20+ Networking Interview Questions with Sample Answers

1. **What is the OSI model and why is it important?**  
   "The OSI model is a conceptual framework with 7 layers: Physical, Data Link, Network, Transport, Session, Presentation, and Application. It helps standardize communication protocols and troubleshoot issues by isolating problems to specific layers. For example, packet loss might be a Transport layer issue, while DNS failures relate to the Application layer."

2. **Explain the difference between TCP and UDP**  
   "TCP is connection-oriented and guarantees delivery via acknowledgments and retransmissions. UDP is connectionless, faster, and used when speed matters more than reliability — like in DNS or video streaming."

3. **What is a subnet and why is it used?**  
   "A subnet divides a network into smaller segments to improve performance and security. It reduces broadcast traffic and allows better IP address management. For example, using CIDR notation like 192.168.1.0/24 defines a subnet with 256 addresses."

4. **How does DNS work?**  
   "DNS translates human-readable domain names into IP addresses. A client queries a recursive resolver, which checks its cache or contacts authoritative servers. DNS caching improves performance, but stale records can cause issues."

5. **What is NAT and how does it work?**  
   "Network Address Translation maps private IPs to public IPs, allowing multiple devices to share a single public IP. It’s essential for IPv4 conservation and firewalling. NAT types include Static, Dynamic, and PAT (Port Address Translation)."

6. **What is the difference between a router and a switch?**  
   "A router connects different networks and routes packets based on IP. A switch connects devices within the same network and forwards frames based on MAC addresses."

7. **What is a VLAN and why would you use it?**  
   "A VLAN logically segments a network at Layer 2. It improves security and performance by isolating traffic. For example, separating dev, QA, and prod environments into different VLANs prevents cross-contamination."

8. **Explain the TCP 3-way handshake**  
   "It establishes a reliable connection: SYN → SYN-ACK → ACK. This synchronizes sequence numbers and ensures both sides are ready to transmit data."

9. **What is ARP and how does it work?**  
   "Address Resolution Protocol maps IP addresses to MAC addresses. When a device wants to send data to an IP, it broadcasts an ARP request. The device with that IP replies with its MAC."

10. **What is a load balancer and how does it work?**  
    "A load balancer distributes traffic across multiple servers. Layer 4 LB uses IP/port, while Layer 7 LB uses HTTP headers or paths. It improves availability and scalability."

11. **What is a firewall and how does it protect a network?**  
    "A firewall filters traffic based on rules. It can block ports, IPs, or protocols. Stateful firewalls track sessions, while stateless ones inspect packets individually."

12. **What is DHCP and how does it work?**  
    "Dynamic Host Configuration Protocol assigns IPs dynamically. The process includes Discover → Offer → Request → Acknowledge. It simplifies IP management."

13. **What is MTU and why does it matter?**  
    "Maximum Transmission Unit is the largest packet size a network can handle. If packets exceed MTU, they’re fragmented or dropped. MTU mismatches can cause performance issues."

14. **What is ICMP and when is it used?**  
    "Internet Control Message Protocol is used for diagnostics — like ping and traceroute. It reports errors like unreachable hosts or TTL expiry."

15. **What is a proxy server?**  
    "A proxy acts as an intermediary between clients and servers. It can cache content, filter traffic, and anonymize requests. Reverse proxies handle incoming traffic to backend services."

16. **What is a VPN and how does it work?**  
    "A Virtual Private Network creates a secure tunnel over public networks using encryption protocols like IPsec or SSL. It’s used for remote access and secure communication."

17. **What is BGP and why is it important?**  
    "Border Gateway Protocol is the backbone of internet routing. It exchanges routing info between autonomous systems. BGP decisions are based on path attributes, not metrics like OSPF."

18. **What is latency vs. throughput?**  
    "Latency is the delay before data starts transferring; throughput is the amount of data transferred over time. High latency affects responsiveness; low throughput affects bulk transfers."

19. **How do you troubleshoot a network issue?**  
    "I start with ping and traceroute to check connectivity and path. Then I inspect DNS resolution, firewall rules, and interface configs. Tools like tcpdump or Wireshark help analyze packet flow."

20. **What is the difference between IPv4 and IPv6?**  
    "IPv4 uses 32-bit addresses (e.g., 192.168.1.1), while IPv6 uses 128-bit (e.g., 2001:db8::1). IPv6 supports more devices and includes built-in security and auto-configuration."

---
