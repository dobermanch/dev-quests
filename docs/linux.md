# Linux

---

## 🧠 What Is the Linux Core?

The Linux core refers to the Linux kernel, which is the heart of any Linux-based operating system. It’s responsible for managing hardware, system resources, and communication between software and hardware.

**Key responsibilities of the kernel:**

- 🧩 Process management: Scheduling and multitasking
- 🗂️ Memory management: Allocating RAM and virtual memory
- 💾 Device drivers: Interfacing with hardware like disks, GPUs, and network cards
- 🔐 Security: Enforcing permissions and isolation
- 📡 Networking: Handling protocols and sockets

The kernel is monolithic, meaning it runs entirely in kernel space, but it’s modular — you can load/unload components dynamically.

---

## 🧬 What Are Linux Distributions?

A Linux distribution (distro) is a complete operating system built around the Linux kernel, bundled with:

- System libraries
- Package managers
- Desktop environments (optional)
- Utilities and applications

Each distro customizes the user experience, update cadence, and tooling based on its goals.

### 🧭 Popular Linux Distributions by Category

| Distro        | Based On   | Best For                    | Package Manager |
|---------------|------------|-----------------------------|-----------------|
| Ubuntu        | Debian     | Beginners, cloud, servers   | apt             |
| Debian        | Independent| Stability, servers          | apt             |
| Fedora        | Independent| Developers, bleeding-edge   | dnf             |
| Arch Linux    | Independent| Power users, minimal setups | pacman          |
| CentOS Stream | RHEL       | Enterprise-like environments| dnf             |
| openSUSE      | Independent| Sysadmins, enterprise       | zypper          |
| Alpine Linux  | Independent| Containers, minimal         | apk             |

#### 🧪 Experimental or Niche Distros

- Gentoo: Source-based, highly customizable
- NixOS: Declarative configuration, reproducible builds
- Tiny Core Linux: Ultra-lightweight (under 20MB)
- Tails: Privacy-focused, runs from USB

---

## 🧩 What Are cgroups (Control Groups)?

cgroups are a Linux kernel feature that lets you limit, prioritize, and account for system resources used by a group of processes.

**Key capabilities:**

- 🔧 Resource Limiting: Set CPU, memory, I/O, and network usage caps.
- 📊 Accounting: Track how much resources a group consumes.
- 🚦 Prioritization: Allocate more CPU shares to critical workloads.
- 🧊 Freezing/Thawing: Pause and resume groups of processes.

**Common controllers:**

- cpu, cpuacct: CPU usage and accounting
- memory: RAM and swap limits
- blkio: Disk I/O throttling
- pids: Limit number of processes
- net_cls, net_prio: Network traffic shaping

**Versions:**

- v1: Multiple hierarchies, inconsistent controller behavior
- v2: Unified hierarchy, cleaner API, better integration with systemd

---

## 🧱 What Are Linux Namespaces?

Namespaces isolate kernel resources so that processes think they’re running on their own system.

| Namespace | Isolates         | Example Use                        |
|-----------|------------------|------------------------------------|
| pid       | Process IDs      | Each container has its own PID 1   |
| net       | Network stack    | Separate IPs, interfaces, routing  |
| mnt       | Mount points     | Isolated filesystem views          |
| uts       | Hostname/domain  | Custom hostnames per container     |
| ipc       | Shared memory    | Prevent cross-container IPC        |
| user      | UID/GID mappings | Root inside container ≠ root outside|
| cgroup    | Cgroup hierarchy | Hide real cgroup paths             |
| time      | System clocks    | Fake time for testing or isolation |

**How they work:**

- Processes are assigned to namespaces via `clone()`, `unshare()`, or `setns()`.
- Each namespace type has its own `/proc/<pid>/ns/<type>` entry.
- You can inspect them with `lsns` or `readlink`.

### 🧪 Real-World Usage

**Containers (Docker, Podman, Kubernetes):**

- Combine namespaces + cgroups for full isolation.
- Each container gets its own PID, net, mnt, and user namespaces.
- Resource limits are enforced via cgroups.

**systemd:**

- Uses cgroups v2 to manage services and resource allocation.
- Integrates with `systemctl` and slice units for fine-grained control.

**Security & Performance:**

- Prevent noisy neighbors in multi-tenant systems.
- Limit blast radius of compromised processes.

---

## 🧠 What Is systemd?

systemd is a system and service manager for Linux. It’s the first process (PID 1) that runs after the kernel boots, replacing older init systems like SysV and Upstart. It’s responsible for:

- Bootstrapping the user space
- Managing services and daemons
- Handling logging, networking, and device events
- Enforcing resource limits via cgroups

It’s modular, parallelized, and deeply integrated with the kernel — making it ideal for fast boot times and scalable service orchestration.

### 🧩 Key Components of systemd

| Component      | Purpose                        |
|----------------|-------------------------------|
| systemctl      | Control services and units     |
| journalctl     | View logs from systemd’s journal|
| hostnamectl    | Manage hostname               |
| timedatectl    | Set time and timezone         |
| localectl      | Configure locale and keyboard  |
| loginctl       | Manage user sessions          |
| systemd-analyze| Boot performance analysis     |

### 🧱 Unit Types

systemd uses units to define and manage system resources. Common types include:

- `.service`: Daemons and background processes
- `.socket`: IPC and network sockets
- `.target`: Group of units (like runlevels)
- `.mount`: Filesystem mount points
- `.timer`: Scheduled tasks (cron replacement)
- `.device`, `.swap`, `.path`, `.slice`: Specialized units

Each unit has a declarative config file in `/etc/systemd/system/` or `/usr/lib/systemd/system/`.

### ⚙️ Managing Services

```sh
systemctl start nginx.service
systemctl stop nginx.service
systemctl enable nginx.service   # Start at boot
systemctl status nginx.service
systemctl list-units --type=service
```

You can also inspect dependencies:

```sh
systemctl list-dependencies multi-user.target
```

### 🔐 Integration with cgroups

systemd uses cgroups v2 to isolate and limit resources:

- Each service runs in its own slice (system.slice, user.slice)
- You can set memory, CPU, and I/O limits in unit files
- Use `systemd-cgls` to view the hierarchy

### 🧪 Real-World Use Cases

- Containers: `systemd-nspawn` uses systemd to manage container lifecycles
- Cloud VMs: systemd handles boot, logging, and service orchestration
- CI/CD: systemd timers replace cron for scheduled jobs
- Security: Drop capabilities, sandbox services, and use seccomp profiles

---

## 🧠 What Is a Process in Linux?

A process is a running instance of a program. When you execute a command, the system creates a process with its own memory space, execution context, and unique PID (Process ID).

**Key attributes of a process:**

- PID: Unique identifier
- PPID: Parent process ID
- UID: User who owns the process
- State: Running, sleeping, zombie, etc.
- Priority: Scheduling weight (nice value)
- Resources: CPU, memory, I/O

### 🧬 Process Lifecycle

- Creation: Via `fork()` or `clone()` — duplicates the parent process.
- Execution: Via `exec()` — replaces the process image with a new program.
- Running: Scheduled by the kernel.
- Waiting: For I/O or resources.
- Termination: Exits normally or is killed.

### 🔍 Viewing and Managing Processes

| Command         | Purpose                        |
|-----------------|-------------------------------|
| ps aux          | Snapshot of all processes      |
| top / htop      | Live view of system activity   |
| pgrep           | Find processes by name         |
| kill / killall  | Terminate processes           |
| nice / renice   | Adjust priority               |
| systemctl       | Manage services (processes)   |

### 🧪 Process States

| State | Description                        |
|-------|------------------------------------|
| R     | Running                            |
| S     | Sleeping (waiting for event)       |
| D     | Uninterruptible sleep (I/O wait)   |
| Z     | Zombie (terminated, not reaped)    |
| T     | Stopped (via signal or job control)|

### 🧱 Foreground vs Background

- Foreground: Tied to terminal, interactive.
- Background: Detached, runs silently (`&` or `nohup`).
- Use `jobs`, `fg`, `bg` to manage shell jobs.

### 🧠 Advanced Concepts

- Zombie processes: Dead but still in process table; cleaned by parent via `wait()`.
- Orphan processes: Parent died; adopted by init or systemd.
- Threads: Lightweight processes sharing memory space (`pthread`, `clone()`).
- Signals: Used to control processes (SIGTERM, SIGKILL, SIGSTOP, etc.)

---

## 🧠 What Is a Thread?

A thread is the smallest unit of execution within a process. It shares the same memory space and resources (like file descriptors) with other threads in the same process, but has its own:

- Program counter (instruction pointer)
- Stack (for function calls and local variables)
- Registers (CPU state)

Because threads share memory, they’re lightweight compared to processes — hence the term Lightweight Process (LWP).

### 🧬 Threads vs Processes

| Feature         | Process         | Thread                  |
|-----------------|----------------|-------------------------|
| Memory space    | Isolated       | Shared with other threads|
| Creation overhead| High (fork()) | Low (pthread_create())  |
| Communication   | IPC mechanisms | Direct memory access    |
| Scheduling      | Kernel-level   | Kernel or user-level    |
| Context switching| Expensive     | Lightweight             |

Linux doesn’t distinguish threads from processes at the kernel level — it uses the same `task_struct` for both. Threads are created using the `clone()` syscall with specific flags to share resources.

### 🔧 Thread Management in Linux

Linux uses POSIX threads (pthreads) for thread creation and control. Key APIs include:

- `pthread_create()`: Start a new thread
- `pthread_join()`: Wait for a thread to finish
- `pthread_mutex_*`: Synchronize access to shared data
- `pthread_cond_*`: Coordinate thread execution

Each thread has a unique Thread ID (TID), and you can inspect threads using:

```sh
ps -eLf       # Shows threads per process
top -H        # Thread-level view in top
```

### 🧪 Thread Types

- User-Level Threads (ULT): Managed by user-space libraries; fast but not visible to the kernel.
- Kernel-Level Threads (KLT): Managed by the OS; visible to the scheduler and can run on multiple cores.

Linux uses KLTs, and the kernel schedules them independently across CPUs.

### ⚙️ Thread Synchronization

Because threads share memory, you need synchronization to avoid race conditions:

- Mutexes: Lock critical sections
- Semaphores: Control access to resources
- Condition variables: Signal between threads
- Barriers: Wait for multiple threads to reach a point

### 🚀 Real-World Use Cases

- Web servers: Handle multiple requests concurrently
- Kubernetes: Uses threads in container runtimes and control plane components
- Monitoring agents: Collect metrics in parallel
- CI/CD pipelines: Run build/test steps concurrently

### 🧠 Threads on Multi-Core CPUs: The Big Picture

Each core in a CPU can execute instructions independently. When you have multiple cores, the Linux kernel can schedule multiple threads to run truly in parallel — not just concurrently via time slicing.

**Key concepts:**

- A thread is a unit of execution within a process.
- A core is a physical execution unit.
- Multithreading allows multiple threads to run simultaneously across cores.

### ⚙️ How Linux Schedules Threads Across Cores

Linux uses the Completely Fair Scheduler (CFS) to distribute threads across cores:

- It maintains a run queue per core.
- Threads are assigned based on load balancing, CPU affinity, and NUMA topology.
- The kernel tries to keep threads on the same core (cache locality) unless load balancing is needed.

You can inspect thread-core mapping with:

```sh
ps -eLo pid,tid,class,rtprio,ni,pri,psr,stat,comm
```

(`psr` shows the processor/core the thread is running on)

### 🧵 Thread Execution Models

| Model | Description                                 | Example Use Case         |
|-------|---------------------------------------------|-------------------------|
| 1:1   | Each thread maps to one kernel thread       | POSIX threads (pthread) |
| M:N   | Many user threads mapped to fewer kernel threads | Green threads, coroutines |
| Hybrid| Mix of user and kernel threads              | Java Virtual Machine    |

Linux uses 1:1 threading, meaning each thread is visible to the kernel and can be scheduled independently.

### 🚀 Benefits of Multi-Core Threading

- True parallelism: Multiple threads run simultaneously on different cores.
- Improved throughput: Ideal for CPU-bound workloads like data processing or simulation.
- Responsiveness: UI threads stay snappy while background threads crunch data.

### 🧪 Real-World Example

Imagine a web server:

- One thread handles incoming requests.
- Another thread processes business logic.
- A third thread writes logs to disk.

On a quad-core CPU, these threads can run in parallel, reducing latency and improving throughput.

---

## 🧱 What Is a Linux Container?

A Linux container is a set of processes that run in isolation from the rest of the system, but share the same kernel. Unlike virtual machines, containers don’t emulate hardware or run separate OS instances — they use OS-level virtualization.

### 🧩 Core Technologies Behind Containers

Linux containers rely on several kernel features:

| Feature      | Purpose                              | Example Tools         |
|--------------|--------------------------------------|----------------------|
| Namespaces   | Isolate system resources (PID, net, etc.) | unshare, lsns    |
| cgroups      | Limit and account resource usage     | systemd, cgroupfs    |
| UnionFS      | Layered filesystem for images        | overlayfs, aufs      |
| Capabilities | Fine-grained privilege control       | capsh, setcap        |
| Seccomp      | Restrict syscalls for security       | seccomp-tools        |
| AppArmor / SELinux | Mandatory access control       | aa-status, getenforce|

These features combine to give containers their isolation, resource control, and security.

### 🛠 How Containers Are Created

- **Image:** A container starts from an image — a layered filesystem with binaries, libraries, and configs.
- **Runtime:** A container runtime (like Docker, containerd, or Podman) sets up namespaces and cgroups.
- **Process Launch:** The containerized process runs inside the isolated environment.
- **Networking:** Virtual interfaces and bridges connect containers to the host or each other.
- **Storage:** Union filesystems allow copy-on-write behavior for efficient layering.

#### 🐳 Example: Docker on Linux

When you run `docker run nginx`, Docker:

- Pulls the image from a registry
- Sets up namespaces (PID, net, mnt, etc.)
- Applies cgroup limits (e.g. memory, CPU)
- Mounts the image layers using overlayfs
- Starts the nginx process inside the container

From the host’s perspective, it’s just another process — but with a completely isolated view of the system.

### 🧪 Real-World Use Cases

- Kubernetes: Orchestrates containers across clusters using container runtimes and Linux primitives.
- Systemd: Uses cgroups v2 to manage services with resource constraints.
- CI/CD Pipelines: Containers provide reproducible environments for builds and tests.

---

## 🧠 What Is POSIX?

POSIX stands for Portable Operating System Interface. It’s an IEEE standard (1003.1) that defines a consistent set of APIs, shell utilities, and interfaces so that software can run across different UNIX-like systems without modification.

Think of it as a contract between applications and the OS — if both sides follow the rules, portability becomes painless.

### 📦 What Does POSIX Cover?

| Area           | Examples                                 |
|----------------|------------------------------------------|
| System Calls   | fork(), exec(), open(), read()           |
| Shell Utilities| ls, grep, awk, sed, find                 |
| Shell Language | sh syntax, redirection, variables        |
| Threads & Signals | pthread_create(), kill(), sigaction() |
| File System    | Pathnames, permissions, symbolic links   |
| Environment    | PATH, HOME, TERM, locale settings        |

POSIX doesn’t dictate how the OS is built — just how it behaves from the outside.

### 🧬 Why POSIX Matters

- 🔁 Portability: Write once, run anywhere (Linux, BSD, macOS, etc.)
- 🧪 Consistency: Predictable behavior across systems
- 🛠️ Tooling: Enables cross-platform build systems and CI/CD
- 🧱 Foundation: Most modern OSes build on POSIX principles

Even Linux, while not officially certified, is highly POSIX-compliant, especially through glibc and coreutils.

### 🧪 Real-World Examples

- Your bash scripts work on Ubuntu, CentOS, and macOS because of POSIX shell compliance.
- Kubernetes uses POSIX threads and signals in its control plane components.
- CI tools like Jenkins and GitHub Actions rely on POSIX utilities for scripting and orchestration.

### 🧠 POSIX vs GNU

GNU tools (like grep, sed, ls) often extend POSIX behavior:

- POSIX: `grep pattern file`
- GNU: `grep -P 'regex' file` (Perl-style regex — not POSIX)

So while GNU adds power, POSIX ensures baseline compatibility.

---

## Channels

### 🔌 1. I/O Channels (Standard Streams)

Linux defines three standard I/O channels for every process:

| Channel | Descriptor | Purpose            |
|---------|------------|--------------------|
| stdin   | 0          | Standard input     |
| stdout  | 1          | Standard output    |
| stderr  | 2          | Standard error     |

These are implemented as file descriptors, and can be redirected or piped:

```sh
command > output.txt       # stdout to file
command 2> error.log       # stderr to file
command < input.txt        # stdin from file
```

### 🧵 2. Channels in IPC (Inter-Process Communication)

In IPC, a channel is a communication path between processes. Common types:
- Unnamed pipes: Temporary, used between parent-child processes.
- Named pipes (FIFOs): Persistent, created with `mkfifo`.
- Sockets: Bidirectional channels over networks or local domains.
- Message queues: POSIX or System V style, for structured messaging.
- Shared memory: Fast, but requires synchronization (e.g. semaphores).

Each of these can be considered a “channel” for data exchange.

### 🧠 3. Kernel-Level Channels

At the kernel level, channels are abstracted as streams of bytes between a process and a file-like object:
- Regular files
- Devices (`/dev`)
- Sockets
- Pipes
- Pseudoterminals (`/dev/pts/*`)

The kernel uses structures like `task_struct` and `file` to manage these connections.

---

## 🔌 What Is a Socket?

A socket is an endpoint for communication between two machines or processes. In Linux, sockets are treated like file descriptors — you can `read()`, `write()`, and `close()` them just like files.

They support both:

- Inter-process communication (IPC) on the same host
- Network communication across machines

### 🧬 Socket Types in Linux

| Type         | Protocol | Description                | Use Case                |
|--------------|----------|----------------------------|-------------------------|
| SOCK_STREAM  | TCP      | Reliable, connection-oriented | Web servers, APIs    |
| SOCK_DGRAM   | UDP      | Unreliable, connectionless   | DNS, VoIP, gaming     |
| SOCK_RAW     | Custom   | Direct access to lower-level protocols | Ping, traceroute, firewalls |
| SOCK_SEQPACKET | Custom | Reliable, preserves message boundaries | Specialized IPC      |

Each socket is created with:

```c
int sockfd = socket(domain, type, protocol);
```

Where:

- domain: AF_INET, AF_INET6, AF_UNIX, etc.
- type: SOCK_STREAM, SOCK_DGRAM, etc.
- protocol: Usually 0 (default for type)

### 🧠 Socket Domains

| Domain      | Purpose                  |
|-------------|-------------------------|
| AF_INET     | IPv4 networking         |
| AF_INET6    | IPv6 networking         |
| AF_UNIX     | Local IPC via filesystem paths |
| AF_NETLINK  | Kernel-user communication|
| AF_PACKET   | Raw access to network interfaces |

### 🧪 Socket Lifecycle

- Create: `socket()`
- Bind: `bind()` to an address/port
- Listen: `listen()` for incoming connections (TCP)
- Accept: `accept()` a connection
- Communicate: `send()`, `recv()` or `read()`, `write()`
- Close: `close()` the socket

For UDP, you skip `listen()` and `accept()` — it’s connectionless.

### 🧱 UNIX Domain Sockets

Used for IPC between processes on the same machine. Instead of IP/port, they use a file path: `/tmp/app.sock`

**Benefits:**

- Faster than TCP (no network stack)
- Secure via filesystem permissions
- Used by Docker, systemd, Redis, MySQL

### 🔐 Security & Performance

- Use non-blocking sockets (`SOCK_NONBLOCK`) for async I/O
- Apply TLS for encrypted communication (OpenSSL, GnuTLS)
- Monitor with `ss`, `netstat`, `lsof`, `tcpdump`

---

## 🧱 What Is a File System in Linux?

A file system defines how data is stored, organized, accessed, and managed on a storage device. In Linux, everything is treated as a file — including devices, processes, sockets, and directories.

### 🌳 Linux File System Hierarchy

Linux uses a single-rooted tree structure, starting at `/` (root). Key directories include:

| Directory | Purpose                                 |
|-----------|-----------------------------------------|
| /bin      | Essential user binaries (e.g. ls, cp)   |
| /etc      | System configuration files              |
| /home     | User-specific data and settings         |
| /var      | Variable data like logs and caches      |
| /dev      | Device files (e.g. /dev/sda)            |
| /proc     | Virtual filesystem for kernel/process info|
| /boot     | Bootloader and kernel files             |
| /tmp      | Temporary files (cleared on reboot)     |

This structure is standardized by the Filesystem Hierarchy Standard (FHS).

### 🧬 File System Layers

Linux file systems operate across three layers:

- Logical File System: Interface for user applications (`open()`, `read()`, `write()`)
- Virtual File System (VFS): Abstracts different file system types (ext4, XFS, etc.)
- Physical File System: Manages actual disk blocks and I/O

### 📦 Common Linux File System Types

| File System | Highlights                        | Use Case                  |
|-------------|-----------------------------------|---------------------------|
| ext4        | Journaling, stable, widely supported | Default on most distros |
| XFS         | High-performance, scalable        | Large files, parallel I/O |
| Btrfs       | Snapshots, compression, checksums | Modern servers, Fedora    |
| ZFS         | RAID-Z, deduplication, self-healing| Enterprise storage        |
| FAT32/exFAT | Cross-platform, no journaling     | USB drives, SD cards      |
| NTFS        | Windows compatibility             | Dual-boot or shared drives|

Each has trade-offs in performance, reliability, and feature set.

### 🧠 Key Features of Linux File Systems

- Journaling: Logs metadata changes to prevent corruption (ext3, ext4, XFS)
- Inodes: Store metadata (owner, permissions, timestamps)
- Mounting: Attach file systems to the hierarchy (`mount`, `umount`)
- Permissions: Controlled via `chmod`, `chown`, and ACLs
- Snapshots: Point-in-time copies (Btrfs, ZFS)
- Compression & Deduplication: Save space (Btrfs, ZFS)
- Versioning: Some FSs store historical versions of files

### 🧪 Real-World Applications

- Containers: Use OverlayFS for layered storage
- Cloud VMs: Often use ext4 or XFS with journaling
- CI/CD Pipelines: Rely on fast I/O and snapshotting
- Monitoring & Logging: `/var` and journaling FSs ensure durability

---

## 🔗 What Are Links in Linux?

A link is a reference to a file. Linux supports two types:

- **Hard links:** Direct references to the file’s inode (actual data).
- **Soft links (symbolic links):** Pointers to the file’s pathname.

### 🧱 Hard Links

**Characteristics:**

- Share the same inode as the original file.
- Point directly to the data blocks on disk.
- Changes to one hard link affect all others.
- Survive deletion of the original filename.
- Cannot link to directories or span across file systems.

Create a hard link:

```sh
ln original.txt hardlink.txt
```

Check inode:

```sh
ls -li original.txt hardlink.txt
```

If both files share the same inode number, they’re hard-linked.

### 🧵 Soft Links (Symbolic Links)

**Characteristics:**

- Have a different inode from the target file.
- Store the path to the original file.
- Break if the target is moved or deleted (dangling link).
- Can link to directories.
- Can span across file systems.

Create a soft link:

```sh
ln -s /path/to/original.txt symlink.txt
```

Identify symbolic links:

```sh
ls -l symlink.txt
```

You’ll see an arrow (`->`) pointing to the target file.

### 🧠 Hard vs Soft Links — Quick Comparison

| Feature         | Hard Link         | Soft Link         |
|-----------------|-------------------|-------------------|
| Inode           | Same as original  | Different         |
| File system scope| Same file system | Can cross FS      |
| Directory linking| Not allowed      | Allowed           |
| Target deletion | Link still works  | Link breaks       |
| Use case        | Backup, deduplication | Shortcuts, flexible refs |

### 🧪 Real-World Use Cases

- Backups: Use hard links to avoid duplicating data (`cp -al`).
- Container volumes: Use symlinks to redirect paths.
- Dev environments: Link config files across projects.
- System binaries: `/bin/sh → /bin/bash` via symlink.

---

## 📄 What is file descriptor (FD)?

In Linux, a file descriptor (FD) is a non-negative integer that uniquely identifies an open file or I/O resource within a process. It’s how the kernel tracks and manages access to things like files, sockets, pipes, and devices — essentially anything you can read from or write to.

### 🧠 Core Concepts

- Every process gets three default file descriptors:

| FD | Name    | Purpose                   |
|----|---------|---------------------------|
| 0  | stdin   | Standard input (keyboard) |
| 1  | stdout  | Standard output (terminal)|
| 2  | stderr  | Standard error (logs)     |

- When you open a file (via `open()` or `fopen()`), the kernel assigns the lowest available FD to it.
- You can use system calls like `read(fd, ...)`, `write(fd, ...)`, and `close(fd)` to interact with the resource.

### 📦 How It Works Under the Hood

- Each process has a file descriptor table in memory.
- That table maps FDs to file table entries, which include:
  - File mode (read/write)
  - File offset (position)
  - Pointer to the inode (actual file metadata)

This layered structure allows multiple processes to share access to the same file while maintaining their own read/write positions.

### 🔧 Common Commands

- View open FDs for a process:
  
  ```sh
  ls -l /proc/<PID>/fd
  ```

- List all open files system-wide:

  ```sh
  lsof
  ```

- Check FD limits:

  ```sh
  ulimit -n
  ```

### 🧪 Real-World Use Cases

- Web servers: Each connection uses a socket FD.
- Container runtimes: Use UNIX domain sockets and pipes.
- CI/CD pipelines: Redirect output streams for logging and debugging.

---

## 🌐 Core Concepts of Linux Networking

### 🧩 Network Interfaces

- Represent physical or virtual connections (e.g. eth0, wlan0, lo)
- Use `ip link`, `ifconfig`, or `nmcli` to view and configure them
- Interfaces can be wired, wireless, loopback, or virtual (like bridges or tunnels)

### 📡 IP Addressing & Routing

- IP addresses assigned via DHCP or statically
- Routing tables define how packets travel between networks

```sh
ip route show
```

### 🧠 DNS & Name Resolution

- `/etc/resolv.conf` defines DNS servers
- Tools: `dig`, `nslookup`, `host`
- `/etc/hosts` for local overrides

### 🔐 Firewall & Security

- `iptables` or `nftables` for packet filtering and NAT
- `ufw` and `firewalld` offer simplified interfaces
- SELinux and AppArmor add mandatory access controls

### 🛠️ Essential Networking Commands

| Command      | Purpose                        |
|--------------|-------------------------------|
| ip           | Manage interfaces, routes, addresses |
| ping         | Test connectivity             |
| traceroute   | Show packet path across networks|
| netstat / ss | View socket and connection info|
| curl / wget  | Transfer data over protocols  |
| tcpdump      | Capture and analyze packets   |
| nmap         | Scan ports and services       |

### 🧪 Advanced Tools & Use Cases

- NetworkManager: GUI and CLI (`nmcli`) for managing connections
- systemd-networkd: Lightweight alternative for headless systems
- netplan: YAML-based config system used in Ubuntu
- bridge-utils: Create virtual bridges for containers or VMs
- veth pairs: Used in container networking to link namespaces

### 🧱 Real-World Applications

- Containers: Use virtual interfaces, bridges, and namespaces
- Cloud VMs: Often use DHCP and cloud-init for config
- Distributed Systems: Rely on DNS, service discovery, and overlay networks
- Monitoring: Tools like iftop, bmon, vnstat, iperf

---

## 👤 What Is a User in Linux?

A user is an identity used to access system resources. Each user has:

- A username
- A UID (User ID)
- A home directory
- A default shell
- A set of permissions and group memberships

Linux supports multiple user types:

| Type     | Description                              |
|----------|------------------------------------------|
| Root     | Superuser with unrestricted access       |
| Standard | Regular user with limited privileges     |
| System   | Used by services (e.g. mysql, nginx)     |
| Sudo     | Standard user with elevated privileges   |
| Guest    | Temporary user with minimal access       |

### 🧑‍🤝‍🧑 What Are Groups?

A group is a collection of users that share access rights. Groups simplify permission management by assigning access to a resource once — and letting all group members inherit it.

Each user has:

- A primary group (defined in `/etc/passwd`)
- Supplementary groups (listed in `/etc/group`)

### 🛠️ Key Files for User & Group Management

| File             | Purpose                                 |
|------------------|-----------------------------------------|
| /etc/passwd      | Basic user info (username, UID, shell)  |
| /etc/shadow      | Encrypted passwords and aging policies  |
| /etc/group       | Group definitions and memberships       |
| /etc/gshadow     | Secure group password data              |
| /etc/sudoers     | Sudo access rules                       |
| /etc/login.defs  | Default user creation policies          |
| /etc/skel/       | Template files for new users            |

### 🔧 Common Commands

| Task                  | Command Example                      |
|-----------------------|--------------------------------------|
| List users            | `awk -F: '{print $1}' /etc/passwd`   |
| Add user              | `sudo useradd username`              |
| Set password          | `sudo passwd username`               |
| Modify user           | `sudo usermod -d /new/home username` |
| Delete user           | `sudo userdel -r username`           |
| Create group          | `sudo groupadd devs`                 |
| Add user to group     | `sudo usermod -aG devs username`     |
| Remove user from group| `sudo gpasswd -d username devs`      |
| List user groups      | `id username` or `groups username`   |
| List all groups       | `cut -d: -f1 /etc/group`             |
| View user info        | `id alice` or `getent passwd alice`  |
| Lock/unlock account   | `sudo usermod -L alice` / `-U alice` |

### 🧠 Core Principles of Proper User Management

- Unique Accounts for Each User: Avoid shared accounts to ensure traceability.
- Assign meaningful usernames and UIDs.
- Use Groups for Access Control: Create role-based groups (e.g. devs, ops, qa) and assign users accordingly.
- Manage permissions at the group level to simplify administration.
- Least Privilege Principle: Grant only the access needed for a user’s role.
- Use sudo for temporary elevation — never give root access directly.
- Password Policies: Enforce complexity, expiration, and lockout rules via `/etc/login.defs` or PAM.
- Use `passwd`, `chage`, and `faillog` to manage password aging and failures.
- Audit and Monitor: Track login attempts via `/var/log/auth.log` or `journalctl`. Use `auditd` for deeper activity tracking.

### 🔐 Security Best Practices

- Use `usermod -e YYYY-MM-DD` to set account expiration.
- Disable unused accounts with `usermod -L`.
- Rotate passwords regularly and enforce 2FA if possible.
- Avoid using root directly — configure granular sudo rules.

### 🧪 Real-World Strategy

For a production system:

- Create system accounts for services (nginx, mysql) with no login shell.
- Use groups like docker, developers, monitoring to manage access.
- Automate provisioning with Ansible or cloud-init.
- Regularly audit `/etc/passwd`, `/etc/group`, and `/var/log/auth.log`.
- Dev teams: Group users by project (frontend, backend, infra)
- CI/CD pipelines: Use system accounts with limited access
- Container runtimes: Isolate users and groups per namespace
- Security audits: Track sudo usage and group memberships

---

## 🔐 Permission management

Permission management in Linux is all about controlling who can do what with files, directories, and system resources. It’s a key part of system security and multi-user coordination.

### 🔐 Linux Permission Model

Every file and directory has:

- Owner: Usually the creator
- Group: A set of users with shared access
- Others: Everyone else

Each of these can have:

- Read (r): View contents
- Write (w): Modify contents
- Execute (x): Run as a program or enter a directory

Permissions are displayed like this:

```bash
-rwxr-xr-- 1 alice devs 1234 Jul 10  report.sh
```

This means:

- Owner (alice) has rwx
- Group (devs) has r-x
- Others have r--

### 🛠️ Managing Permissions

| Task              | Command Example           |
|-------------------|--------------------------|
| Change permissions| `chmod 755 file.sh`      |
| Recursive change  | `chmod -R 644 /var/www`  |
| Change owner      | `chown bob file.txt`     |
| Change group      | `chown :devs file.txt`   |
| Change both       | `chown bob:devs file.txt`|
| View permissions  | `ls -l` or `stat file.txt`|

### 🧠 Advanced Permission Concepts

- Symbolic vs Numeric Modes:
  - Symbolic: `chmod u+x file.sh`
  - Numeric: `chmod 755 file.sh` → rwxr-xr-x
- Default Permissions:
  - Controlled by `umask` (e.g. `umask 022`)
- Sticky Bit:
  - Used on shared directories like `/tmp`
  - Only file owner can delete their files: `chmod +t /shared`
- SetUID / SetGID:
  - Run with file owner's or group’s privileges
  - Example: `chmod u+s /usr/bin/somebinary`

### 🧪 Real-World Practices

- Use groups to manage access across teams.
- Avoid 777 — it gives full access to everyone.
- Audit with `find / -perm -4000` to locate risky SetUID binaries.
- Use ACLs (`getfacl`, `setfacl`) for fine-grained control beyond basic permissions.

---

## Linux user management: sudo and su

Let’s break down two of the most powerful tools in Linux user management: sudo and su. They both elevate privileges, but they do so in very different ways — and understanding the distinction is key to secure and efficient system administration.

### 🔐 sudo (Superuser Do)

**Purpose:** Run a specific command as another user (usually root) without switching users.

**Key traits:**

- Uses the current user's password for authentication.
- Requires the user to be listed in `/etc/sudoers` or part of the sudo group.
- Logs every command for auditing.
- Grants temporary elevated privileges — ideal for secure environments.

**Example:**

```sh
sudo apt update
```

Runs `apt update` with root privileges.

**Advanced usage:**

```sh
sudo -u postgres psql
```

Runs `psql` as the postgres user.

**Best practices:**

- Use `visudo` to safely edit the sudoers file.
- Prefer sudo over su for traceability and granular control.
- Use `sudo -i` for a root-like shell with root’s environment.

### 👤 su (Substitute User)

**Purpose:** Switch to another user account entirely — often root.

**Key traits:**

- Requires the target user's password.
- Starts a new shell session as that user.
- Less granular control; no logging by default.
- Can be used to simulate full login environments.

**Example:**

```sh
su -
```

Switches to root with a full login shell.

Switch to another user:

```sh
su deploy
```

Switches to the deploy user (if you know their password).

Preserve environment:

```sh
su -p deploy
```

### 🧠 sudo vs su — Quick Comparison

| Feature         | sudo                        | su                      |
|-----------------|----------------------------|-------------------------|
| Auth method     | Current user’s password    | Target user’s password  |
| Scope           | One command                | Full shell session      |
| Logging         | Yes                        | No (unless configured)  |
| Granular control| Yes (sudoers)              | No                     |
| Recommended for | Secure, multi-user systems | Single-user or legacy   |

### 🧪 Real-World Usage

- CI/CD pipelines: Use sudo for controlled privilege escalation.
- System recovery: Use su when you need full root access offline.
- Container entrypoints: Often use su to switch to non-root users.
- Security audits: Prefer sudo for traceability and accountability.

---

## 🧠 What Is a Linux Driver?

A device driver is a kernel-level module that allows the operating system to communicate with hardware devices. It abstracts the hardware details and exposes a standardized interface to user-space applications.

In Linux, even hardware is treated as a file — typically under `/dev` — which makes interaction consistent and scriptable.

### 🧩 Types of Linux Drivers

| Type      | Description                   | Examples                   |
|-----------|------------------------------|----------------------------|
| Character | Transfers data byte-by-byte   | Keyboard, serial ports, /dev/tty |
| Block     | Transfers data in blocks      | Hard drives, SSDs, /dev/sda      |
| Network   | Sends/receives packets        | Ethernet, Wi-Fi adapters         |
| Pseudo    | No physical device, but behaves like one | /dev/null, /dev/zero |

Each type has its own interface and behavior, but all are managed via kernel modules.

### 🧬 Kernel Modules vs Drivers

- A kernel module is any loadable piece of code that extends kernel functionality.
- A driver is a specific type of module that interfaces with hardware.

Drivers can be:

- Built into the kernel (static)
- Loaded dynamically (`modprobe`, `insmod`)
- Auto-loaded at boot via `/etc/modules-load.d/`

### 🛠️ Managing Drivers

| Task                | Command Example             |
|---------------------|----------------------------|
| List loaded modules | `lsmod`                    |
| Load a module       | `sudo modprobe <module>`   |
| Unload a module     | `sudo modprobe -r <module>`|
| View module info    | `modinfo <module>`         |
| List device files   | `ls -l /dev`               |

You can also inspect PCI devices with `lspci` and USB devices with `lsusb`.

### 🔐 Driver Security & Stability

- Use signed modules for integrity.
- Avoid proprietary drivers unless necessary (e.g. NVIDIA).
- Monitor kernel logs with `dmesg` for driver-related errors.
- Use udev rules to manage device behavior dynamically.

### 🧪 Real-World Applications

- Cloud VMs: Use virtual drivers like virtio for performance.
- Embedded systems: Custom drivers for sensors and GPIO.
- Container runtimes: Rely on kernel modules for overlay filesystems and network interfaces.
- CI/CD agents: Use drivers for USB, disk, and network automation.

---

## 🧠 What Are Linux Capabilities?

Traditionally, processes either ran as:

- Privileged (UID 0 / root) — full access to everything
- Unprivileged (non-root) — restricted by file permissions and system policies

Starting with Linux kernel 2.2, capabilities were introduced to split root privileges into discrete units. Each unit (capability) governs a specific action — like binding to a low-numbered port or loading a kernel module.

### 🔐 Examples of Common Capabilities

| Capability             | Purpose                                 |
|------------------------|-----------------------------------------|
| CAP_NET_BIND_SERVICE   | Bind to ports < 1024                    |
| CAP_SYS_ADMIN          | Perform system-wide admin tasks (very broad) |
| CAP_CHOWN              | Change file ownership                   |
| CAP_DAC_OVERRIDE       | Bypass file permission checks           |
| CAP_SETUID / SETGID    | Change user/group IDs                   |
| CAP_SYS_MODULE         | Load/unload kernel modules              |
| CAP_NET_ADMIN          | Configure network interfaces, routing, firewall |
| CAP_SYS_TIME           | Set system clock                        |
| CAP_SYS_BOOT           | Reboot the system                       |

There are ~40 capabilities in modern kernels.

### 🧩 Capability Sets

Each process has multiple capability sets:

- Permitted: What the process is allowed to use
- Effective: What it's actively using
- Inheritable: What can be passed to child processes
- Bounding: Upper limit of what can be gained
- Ambient: Used in user namespaces and containers

You can inspect them via:

```sh
cat /proc/<pid>/status | grep Cap
```

### 🛠️ Managing Capabilities

Use these tools:

- `getcap`: View capabilities on executables
- `setcap`: Assign capabilities to executables
- `capsh`: Inspect and manipulate capabilities interactively
- `getpcaps`: View capabilities of running processes

**Example:**

```sh
sudo setcap cap_net_bind_service=ep /usr/bin/myserver
```

This allows `myserver` to bind to port 80 without needing root.

### 🧪 Real-World Use Cases

- Rootless containers: Grant CAP_NET_BIND_SERVICE to allow binding to port 80
- Security hardening: Replace setuid binaries with minimal capabilities
- System services: Use systemd to assign capabilities via unit files

---

## 📦 What Is Package Management?

Package management is the process of installing, upgrading, configuring, and removing software packages on a Linux system. A package typically includes:

- Precompiled binaries
- Configuration files
- Metadata (name, version, dependencies)
- Scripts for install/uninstall

Package managers automate dependency resolution, version control, and repository access — saving you from “dependency hell.”

### 🧰 Popular Linux Package Managers

| Package Manager | Distros           | Format   | Highlights                  |
|-----------------|-------------------|----------|-----------------------------|
| APT             | Debian, Ubuntu    | .deb     | Reliable, dependency-aware  |
| YUM / DNF       | RHEL, CentOS, Fedora | .rpm | DNF is faster, modern replacement |
| Pacman          | Arch, Manjaro     | .tar.xz  | Lightweight, fast, rolling updates |
| Zypper          | openSUSE          | .rpm     | Transaction-safe, repo-friendly   |
| Portage         | Gentoo            | Source   | Highly customizable, source-based |
| Slackpkg        | Slackware         | .tgz     | Minimalist, manual control       |

Each manager interfaces with repositories — curated collections of packages — and handles updates, installs, and removals.

### 🛠️ Common Commands by Manager

**APT (Debian/Ubuntu):**

```sh
sudo apt update             # Refresh package list
sudo apt install nginx      # Install package
sudo apt remove nginx       # Remove package
sudo apt upgrade            # Upgrade all packages
```

**DNF (Fedora/RHEL):**

```sh
sudo dnf install nginx
sudo dnf remove nginx
sudo dnf upgrade
```

**Pacman (Arch):**

```sh
sudo pacman -S nginx        # Install
sudo pacman -R nginx        # Remove
sudo pacman -Syu            # Update system
```

**Zypper (openSUSE):**

```sh
sudo zypper install nginx
sudo zypper remove nginx
sudo zypper update
```

### 🔐 Best Practices

- ✅ Use official repositories for stability and security
- 🔄 Regularly update packages (`apt upgrade`, `dnf upgrade`)
- 🧼 Clean up unused dependencies (`apt autoremove`)
- 🔍 Audit installed packages (`dpkg -l`, `rpm -qa`)
- 🧪 Avoid mixing package managers — it can break dependency resolution

### 🧪 Real-World Applications

- CI/CD pipelines: Automate installs with package managers
- Container builds: Use minimal base images with apk, apt, or dnf
- Security patching: Schedule updates via cron or systemd timers
- Custom repos: Host internal packages for enterprise deployments

---

## 🐚 What Is a Shell?

A shell is a command-line interpreter that lets users interact with the operating system. It translates human-readable commands into kernel-level instructions.

**Popular shells:**

- Bash (Bourne Again SHell) – default on most Linux distros
- Zsh – feature-rich, great for interactive use
- Ksh – scripting-friendly, POSIX-compliant
- Fish – user-friendly, auto-suggestions
- Dash – lightweight, used in Ubuntu’s /bin/sh

You can check your current shell with:

```sh
echo $SHELL
```

### 📜 What Is Shell Scripting?

A shell script is a file containing a sequence of shell commands. It automates tasks like backups, deployments, monitoring, and system configuration.

**Basic structure:**

```bash
#!/bin/bash
echo "Hello, Sergii!"
```

- `#!/bin/bash` is the shebang, telling the system which shell to use.
- Save as `myscript.sh`, make it executable with `chmod +x myscript.sh`, and run it with `./myscript.sh`.

### 🧠 Key Scripting Concepts

**Variables:**

```bash
name="Sergii"
echo "Welcome, $name"
```

**Conditionals:**

```bash
if [ "$name" == "Sergii" ]; then
  echo "Architect mode activated"
fi
```

**Loops:**

```bash
for i in {1..3}; do
  echo "Iteration $i"
done
```

**Functions:**

```bash
greet() {
  echo "Hello, $1"
}
greet "Sergii"
```

**User input:**

```bash
read -p "Enter your role: " role
echo "You are a $role"
```

### 🛠️ Real-World Use Cases

- CI/CD pipelines: Automate build/test/deploy steps
- System provisioning: Set up users, install packages, configure services
- Monitoring scripts: Check disk usage, CPU load, service health
- Container entrypoints: Bootstrap environments in Docker images

### 🔐 Best Practices

- Use `set -euo pipefail` to catch errors early
- Validate inputs and sanitize variables
- Modularize with functions and external config files
- Log output and errors for debugging
- Prefer POSIX-compliant syntax for portability

---

## 🔗 What Is a Pipe in Linux?

A pipe (`|`) is a mechanism that redirects the standard output (stdout) of one command into the standard input (stdin) of another. It allows commands to work together without intermediate files.

**Syntax:**

```sh
command1 | command2 | command3
```

Each command processes the data and passes it along — like a relay race.

### 🧠 How Pipes Work Internally

- Pipes are implemented in memory using file descriptors.
- The shell creates a unidirectional buffer between processes.
- Data flows left to right through the pipeline.
- Each command runs in its own process, often in parallel.

### 🛠️ Common Pipe Examples

| Task                  | Command                        |
|-----------------------|-------------------------------|
| Filter files by name  | `ls | grep ".log"`            |
| Count matching lines  | `grep "error" syslog | wc -l` |
| View long output page | `ps aux | less`               |
| Sort and deduplicate  | `cat names.txt | sort | uniq` |
| Extract columns       | `ls -l | awk '{print $9}'`    |

You can chain multiple commands to build powerful one-liners.

### 🧪 Real-World Use Cases

- Monitoring logs: `tail -f /var/log/syslog | grep "WARN"`
- CI/CD pipelines: Combine build/test/report steps
- Data processing: `cat data.csv | cut -d',' -f2 | sort | uniq -c`
- Security audits: `find / -perm -4000 | xargs ls -l`

### 🧱 Named Pipes (FIFO)

Named pipes are persistent and created with:

```sh
mkfifo /tmp/mypipe
```

They allow communication between unrelated processes and survive across sessions.

---

## 🔁 What Are Redirects in Linux?

Redirects allow you to reroute the standard streams of a process:

- stdin (0): Standard input — usually the keyboard
- stdout (1): Standard output — usually the terminal
- stderr (2): Standard error — also the terminal

You can redirect these streams to files, devices, or other commands.

### 📤 Output Redirection

| Symbol | Purpose                  | Example                   |
|--------|--------------------------|---------------------------|
| >      | Redirect stdout (overwrite) | `ls > files.txt`        |
| >>     | Redirect stdout (append)    | `echo "log" >> logs.txt`|
| 2>     | Redirect stderr            | `badcmd 2> error.log`   |
| 2>>    | Append stderr              | `badcmd 2>> error.log`  |
| &>     | Redirect both stdout & stderr | `cmd &> all.log`      |
| 2>&1   | Merge stderr into stdout   | `cmd > out.log 2>&1`    |

### 📥 Input Redirection

| Symbol | Purpose                  | Example                   |
|--------|--------------------------|---------------------------|
| <      | Redirect stdin from file | `sort < names.txt`        |
| <<     | Here-document            | `cat <<EOF ... EOF`       |
| <&     | Duplicate input FD       | `0<&1`                    |

### 🔗 Combining Redirects

You can mix and match:

```sh
grep "error" logfile.txt > results.txt 2> errors.txt
```

Or merge both outputs:

```sh
grep "error" logfile.txt > combined.txt 2>&1
```

### 🧪 Real-World Use Cases

- Logging: Capture output and errors separately for debugging
- Automation: Feed input from files into scripts
- CI/CD: Redirect build logs and test results
- Security: Suppress noisy errors with `2> /dev/null`

---

## Useful commands

### 📁 File & Directory Management

| Command | Purpose                        | Example                |
|---------|-------------------------------|------------------------|
| ls      | List files and directories     | `ls -l`                |
| cd      | Change directory               | `cd /var/log`          |
| pwd     | Show current directory         | `pwd`                  |
| mkdir   | Create a new directory         | `mkdir backups`        |
| rm      | Remove files or directories    | `rm -rf temp/`         |
| cp      | Copy files or directories      | `cp file.txt /tmp/`    |
| mv      | Move or rename files           | `mv old.txt new.txt`   |
| touch   | Create an empty file           | `touch notes.txt`      |
| find    | Search for files               | `find / -name "*.conf"`|

### 📜 Text Processing & Search

| Command | Purpose                        | Example                |
|---------|-------------------------------|------------------------|
| cat     | Display file contents          | `cat config.yaml`      |
| less    | View large files page-by-page  | `less /var/log/syslog` |
| grep    | Search text using patterns     | `grep "error" logs.txt`|
| awk     | Extract and format text        | `awk '{print $1}' users.txt`|
| sed     | Stream editor for substitution | `sed 's/foo/bar/g' file.txt`|
| cut     | Remove sections from lines     | `cut -d':' -f1 /etc/passwd`|
| sort    | Sort lines of text             | `sort names.txt`       |
| uniq    | Remove duplicate lines         | `uniq sorted.txt`      |
| wc      | Count lines, words, characters | `wc -l file.txt`       |

### ⚙️ System Monitoring & Process Control

| Command | Purpose                        | Example                |
|---------|-------------------------------|------------------------|
| top     | Live system resource monitor   | `top`                  |
| htop    | Enhanced top (if installed)    | `htop`                 |
| ps      | Show running processes         | `ps aux`               |
| kill    | Terminate a process by PID     | `kill 1234`            |
| killall | Terminate processes by name    | `killall nginx`        |
| uptime  | Show system uptime             | `uptime`               |
| free    | Show memory usage              | `free -h`              |
| df      | Show disk space                | `df -h`                |
| du      | Show directory/file size       | `du -sh /var/log`      |

### 🌐 Networking

| Command   | Purpose                        | Example                    |
|-----------|-------------------------------|----------------------------|
| ping      | Test connectivity             | `ping google.com`          |
| curl      | Transfer data from URLs       | `curl https://api.example.com`|
| wget      | Download files from web       | `wget http://example.com/file`|
| ip        | Show network interfaces       | `ip a`                     |
| netstat / ss| Show active connections     | `ss -tuln`                 |
| traceroute| Trace network path            | `traceroute github.com`    |
| nslookup  | DNS lookup                    | `nslookup example.com`     |

### 🔐 User & Permission Management

| Command   | Purpose                        | Example                |
|-----------|-------------------------------|------------------------|
| chmod     | Change file permissions        | `chmod 755 script.sh`  |
| chown     | Change file ownership          | `chown user:group file.txt`|
| useradd   | Add new user                   | `sudo useradd alice`   |
| passwd    | Set or change password         | `passwd alice`         |
| groups    | Show user’s group memberships  | `groups alice`         |
| sudo      | Run command as root            | `sudo apt update`      |

### 🧰 Package Management (by distro)

| Distro        | Manager | Example Command             |
|---------------|---------|----------------------------|
| Debian/Ubuntu | apt     | `sudo apt install nginx`   |
| RHEL/Fedora   | dnf     | `sudo dnf install nginx`   |
| Arch Linux    | pacman  | `sudo pacman -S nginx`     |
| Alpine        | apk     | `apk add nginx`            |

### 🧪 Bonus Utilities

| Command | Purpose                        | Example                |
|---------|-------------------------------|------------------------|
| man     | View manual pages              | `man grep`             |
| alias   | Create command shortcuts       | `alias ll='ls -la'`    |
| history | Show command history           | `history`              |
| clear   | Clear terminal screen          | `clear`                |
| date    | Show current date/time         | `date`                 |
| uptime  | Show system uptime             | `uptime`               |

---

## Questions

1. **What is the difference between a process and a thread in Linux?**  
   A process is an independent execution unit with its own memory space, while a thread is a lightweight process that shares memory within the same parent process. Linux treats both as tasks internally using `task_struct`, and threads are created using `clone()` with flags indicating shared resources.

2. **How are Linux file permissions structured?**  
   Each file has three permission sets: for the owner, group, and others, represented as rwx. You can modify these with `chmod`, `chown`, and use numeric or symbolic modes. For example: `chmod 755 file.sh` sets rwxr-xr-x.

3. **What are inodes?**  
   An inode stores metadata about a file — not its name — such as ownership, permissions, timestamps, and disk block locations. You can inspect inodes with `ls -i` and `stat file`.

4. **Explain cgroups and namespaces.**  
   - cgroups limit and monitor resource usage per process group (e.g., memory, CPU).
   - Namespaces isolate kernel resources per process (e.g., PID, NET, MNT), creating containers.  
   Together, they enable OS-level virtualization used by Docker, Kubernetes, and systemd.

5. **How does systemd differ from init?**  
   systemd is a modern init system that handles service management, parallel startup, cgroup integration, and journaling. It replaced SysV and Upstart in most distros due to its speed and modularity.

6. **What’s the role of a kernel in Linux?**  
   The kernel manages hardware, memory, process scheduling, security, and I/O. It’s monolithic but modular — modules can be loaded/unloaded dynamically using `modprobe`.

7. **What is the difference between hard link and soft link?**  
   - Hard Link: Points directly to inode; file remains until all links are deleted.
   - Soft Link (symlink): Points to filename; breaks if target is removed.

8. **How do you analyze CPU or memory bottlenecks?**  
   Use tools like:
   - `top` / `htop` for real-time stats
   - `vmstat`, `iostat`, `dstat` for historical metrics
   - `pidstat`, `perf`, `strace` for process-level performance
   - `free -m` and `/proc/meminfo` for memory info

9. **How does Linux handle scheduling?**  
   Linux uses the Completely Fair Scheduler (CFS). Tasks are placed in a red-black tree based on virtual runtime (vruntime) and scheduled fairly. You can influence scheduling with `nice`, `renice`, and `chrt` for real-time priorities.

10. **What are file descriptors?**  
    They’re integer handles representing open files or I/O resources. Each process has its own FD table, with descriptors 0, 1, and 2 reserved for stdin, stdout, and stderr. You can view them via `/proc/<pid>/fd`.

11. **How does Linux handle network configuration?**  
    Use the `ip` suite (`ip addr`, `ip link`, `ip route`) to view or configure interfaces. DNS is controlled via `/etc/resolv.conf`, firewall via `iptables` or `nftables`, and network troubleshooting with `ping`, `curl`, `netstat`, `tcpdump`.

12. **What is cron and how do you schedule jobs?**  
    cron is a daemon for scheduling commands. Jobs are defined in crontab:

    ```sh
    crontab -e
    # Example: Run backup every day at midnight
    0 0 * * * /usr/local/bin/backup.sh
    ```

13. **What is the difference between exec() and fork()?**  
    - fork(): Creates a new process by duplicating the current one.
    - exec(): Replaces the current process image with a new program.  
    They're often used together: fork() creates a child, exec() replaces it.

14. **Explain the importance of /proc and /sys.**  
    - /proc: Virtual filesystem for process and kernel info (`/proc/cpuinfo`, `/proc/meminfo`).
    - /sys: Interface for kernel device tree and drivers. Used by udev and systemd.  
    They expose runtime data used by monitoring tools and system introspection.

15. **What are capabilities in Linux?**  
    Capabilities split root privileges into fine-grained rights (e.g. CAP_NET_ADMIN, CAP_SYS_TIME). Programs can request just the privileges they need using `setcap` and `capsh`, reducing security risks.

16. **How do containers isolate workloads in Linux?**  
    Containers use namespaces for isolation (e.g. pid, net, mnt) and cgroups for resource control. OverlayFS enables layered storage, and AppArmor/SELinux restrict access. Runtimes like Docker and containerd set these up behind the scenes.

17. **How do permissions interact with groups and ACLs?**  
    Beyond basic chmod, ACLs (`setfacl`, `getfacl`) allow per-user and per-group rules, including inheritance. Essential for fine-grained access control in shared environments or NFS setups.

---
