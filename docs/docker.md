# Docker

## 🐳 What Is Docker?

Docker is a containerization platform that allows you to package applications and their dependencies into isolated units called containers. These containers run consistently across environments — from dev laptops to production clusters.

- **Containers vs. VMs:** Containers share the host OS kernel, making them lightweight and fast to start, unlike VMs which require full OS stacks.
- **Docker Images:** Immutable blueprints for containers, built from Dockerfiles.
- **Docker Engine:** The runtime that builds and runs containers.
- **Docker Compose:** Tool for defining and running multi-container applications using YAML.
- **Containers:** Lightweight, portable, and share the host OS kernel.
- **Dockerfile:** Script that defines how to build an image.
- **Docker Hub:** Public registry for sharing images.

### ⚙️ Docker Architecture

| Component        | Description                                                        |
| ---------------- | ------------------------------------------------------------------ |
| Docker Client    | CLI tool (`docker`) to interact with Docker                        |
| Docker Daemon    | Background service (`dockerd`) that manages containers and images   |
| Docker Registry  | Stores and distributes images (e.g., Docker Hub or private registries) |
| Container Runtime| Executes containers using OS kernel features (e.g., runc, containerd) |

### 🚀 Use Cases You’d Appreciate

- **CI/CD Pipelines:** Docker standardizes environments, enabling reproducible builds and tests. Ideal for staging and production parity.
- **Microservices:** Each service can run in its own container, simplifying deployment and scaling.
- **Cloud Migration:** Containers abstract away infrastructure, easing lift-and-shift strategies.
- **Legacy App Modernization:** Wrap legacy apps in containers to run on modern infra without rewriting.
- **Multi-tenancy:** Isolate tenants with container-per-tenant models, especially useful in SaaS platforms.

### 🧠 Docker vs Kubernetes

| Feature    | Docker                | Kubernetes                        |
| ---------- | --------------------- | --------------------------------- |
| Scope      | Container runtime     | Container orchestration           |
| Scaling    | Manual or via Swarm   | Automated, declarative            |
| Networking | Basic bridge/network  | Advanced service discovery/ingress|
| Use Case   | Dev/test, simple apps | Production-grade orchestration    |

---

## 🧬 What Is a Docker Image?

A Docker image is a read-only template that defines everything needed to run an application inside a container:

- App code
- Runtime (e.g., Node.js, Python)
- Libraries and dependencies
- Environment variables and config files

Think of it as a snapshot of a fully configured system — the blueprint from which containers are instantiated.

### 🧱 Image Structure: Layers & Caching

Docker images are built in layers, each representing a filesystem change (e.g., adding a file, installing a package):

- **Base Layer:** Often a minimal OS like Alpine or Ubuntu.
- **Intermediate Layers:** App dependencies, configs, etc.
- **Top Layer:** Your application code and entrypoint.

This layered architecture enables efficient caching and reuse across builds. For example, if only your app code changes, Docker reuses the cached layers below.

### 🛠️ Building an Image: Dockerfile Essentials

Here’s a simple Dockerfile example:

```dockerfile
FROM node:18-alpine
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD ["node", "server.js"]
```

Each instruction creates a layer. Best practices include:

- Use multi-stage builds to reduce image size.
- Pin versions to ensure reproducibility.
- Avoid unnecessary files with `.dockerignore`.

### 🧪 Inspecting & Managing Images

Useful commands:

- `docker images`: List local images.
- `docker image inspect <image>`: View metadata.
- `docker image prune`: Remove unused images.
- `docker tag`: Apply version labels.
- `docker push`: Upload to a registry (e.g., Docker Hub).

### 📦 Registries & Distribution

Images are stored in registries:

- **Docker Hub:** Default public registry.
- **Private registries:** For internal use (e.g., AWS ECR, Azure ACR).
- **Verified & Official Images:** Curated and maintained by Docker or trusted publishers.

You can pull images with:

```sh
docker pull nginx:latest
```

And run them:

```sh
docker run -d -p 80:80 nginx
```

### 🔐 Security & Optimization

- Use minimal base images (e.g., alpine) to reduce attack surface.
- Scan images with tools like Trivy or Docker Scout.
- Keep secrets out of images — use env vars or external secret managers.

---

## 📦 What Is a Docker Container?

A Docker container is a lightweight, isolated process that runs on a shared OS kernel but includes everything needed to execute an application:

- App code
- Runtime (e.g., Node.js, Python)
- Libraries and dependencies
- System tools and configs

Containers are portable, consistent, and fast — ideal for modern distributed systems.

### 🧱 How Containers Work

Containers use Linux primitives like cgroups and namespaces to isolate processes:

| Feature    | Purpose                                   |
| ---------- | ----------------------------------------- |
| Namespaces | Isolate process trees, network, and mounts|
| cgroups    | Limit CPU, memory, and I/O usage          |
| UnionFS    | Enables layered file systems for images   |

They run on a container runtime like containerd or runc, which Docker uses under the hood.

### 🚀 Lifecycle of a Container

1. **Write a Dockerfile:** Define base image, dependencies, and startup command.
2. **Build an Image:** `docker build -t my-app .`
3. **Run a Container:** `docker run -d -p 8080:80 my-app`
4. **Manage Containers:**
   - List: `docker ps`
   - Stop: `docker stop <id>`
   - Remove: `docker rm <id>`

Containers are ephemeral by default — they vanish when stopped unless volumes are used.

### 🔄 Containers vs Virtual Machines

| Aspect         | Containers         | Virtual Machines      |
| -------------- | ------------------ | ---------------------|
| Isolation      | Process-level      | Full OS-level        |
| Startup Time   | Seconds            | Minutes              |
| Resource Usage | Minimal            | Heavy                |
| Portability    | High (runs anywhere with Docker) | Lower (depends on hypervisor) |

Containers virtualize the OS, not the hardware — making them lean and fast.

### 🧪 Practical Use Cases

- **Microservices:** Each service in its own container
- **CI/CD:** Reproducible test environments
- **Cloud-native apps:** Portable across clouds
- **Dev environments:** “Works on my machine” solved

### 🔐 Security & Best Practices

- Run as non-root inside containers
- Use read-only file systems where possible
- Scan containers with Trivy, Docker Scout, or Snyk
- Keep secrets out of images — use env vars

---

## 📦 What Are Docker Volumes?

A volume is a persistent storage mechanism managed by Docker that lives outside the container’s writable layer. It allows data to survive container restarts, removals, and updates.

- **Use Case:** Ideal for databases, logs, configs, or any data you don’t want to lose when a container is stopped.
- **Location:** Stored on the host (typically `/var/lib/docker/volumes/` on Linux).
- **Isolation:** Volumes are isolated from the host OS and managed entirely by Docker.

### 🧱 Types of Docker Storage

| Type        | Description                                                                 |
| ----------- | --------------------------------------------------------------------------- |
| Volumes     | Managed by Docker, persistent, portable, and safe to share between containers|
| Bind Mounts | Directly map host paths into containers; less portable and more error-prone |
| Tmpfs Mounts| Stored in memory only; ideal for sensitive or ephemeral data                |

### 🛠️ Creating & Using Volumes

- **Create a volume:**

  ```sh
  docker volume create mydata
  ```

- **Run a container with a volume:**

  ```sh
  docker run -d -v mydata:/app/data my-app
  ```

- **Inspect volume:**

  ```sh
  docker volume inspect mydata
  ```

- **Remove volume:**

  ```sh
  docker volume rm mydata
  ```

- **Prune unused volumes:**

  ```sh
  docker volume prune
  ```

### 🔄 Mounting Volumes

You can mount volumes using either `-v` or `--mount`:

```sh
docker run --mount type=volume,source=mydata,target=/app/data my-app
```

- `--mount` is more explicit and supports advanced options like read-only mounts and subpaths.
- Volumes can be named or anonymous. Named volumes are reusable; anonymous ones are tied to container lifecycle.

**Security & Performance Tips:**

- Use read-only mounts for sensitive data:

  ```sh
  docker run -v mydata:/app/data:ro my-app
  ```

- Avoid storing secrets in volumes — use external secret managers or environment variables.
- Volumes offer better performance than writing to the container’s writable layer.

### 🧪 Docker Compose Integration

```yaml
services:
  app:
    image: my-app
    volumes:
      - mydata:/app/data

volumes:
  mydata:
```

You can also mark volumes as `external: true` to reuse existing ones.

---

## 🧠 What Is /var/run/docker.sock?

It’s a Unix socket file that acts as the local API endpoint for Docker. Instead of using TCP/IP, Docker uses this socket for inter-process communication (IPC) between the client and daemon on the same host.

- **Location:** `/var/run/docker.sock`
- **Protocol:** Unix domain socket (not TCP)
- **Purpose:** Accepts REST API calls from Docker clients

You can even interact with it using curl:

```sh
curl --unix-socket /var/run/docker.sock http://localhost/containers/json
```

### 🛠️ Why Mount It?

Mounting the socket into a container allows that container to control the host’s Docker daemon — meaning it can:

- Start/stop containers
- Build/push images
- Inspect volumes, networks, and more

**Example:**

```sh
docker run -v /var/run/docker.sock:/var/run/docker.sock -it docker
```

This is the basis for Docker-in-Docker (DooD) patterns, often used in CI/CD tools like Jenkins or GitLab runners.

### ⚠️ Security Implications

Mounting the Docker socket gives root-level access to the host system:

- Any container with access can spawn privileged containers
- It can read/write files, modify networks, and bypass isolation
- If compromised, it’s game over for the host

**Best practices:**

- Avoid mounting it in untrusted containers
- Use [docker-socket-proxy](https://github.com/Tecnativa/docker-socket-proxy) to restrict API access
- Consider user namespaces and read-only mounts for mitigation

### 🔐 Permissions & Access Control

- Owned by root and group docker
- Users in the docker group can interact with it:

```sh
sudo usermod -aG docker sergii
```

To inspect permissions:

```sh
ls -l /var/run/docker.sock
```

---

## 🔐 What Are Docker Secrets?

Docker secrets are encrypted blobs of sensitive data that are securely managed and distributed to containers only when needed. They’re designed to prevent secrets from being hardcoded into images or exposed via environment variables.

- **Examples:** DB passwords, SSH keys, TLS certs, OAuth tokens
- **Scope:** Available only to Docker Swarm services, not standalone containers

### 🧱 How Secrets Work in Docker Swarm

| Step             | Description                                                                 |
| ---------------- | --------------------------------------------------------------------------- |
| Create Secret    | `echo "mypassword" \| docker secret create db_password -`                    |
| Attach to Service| `docker service create --name app --secret db_password myapp:latest`        |
| Access in Container | Mounted at `/run/secrets/db_password` (Linux) or `C:\ProgramData\Docker\secrets` (Windows) |
| Secure by Design | Encrypted at rest and in transit; only accessible to authorized services    |

Secrets are stored in the Swarm’s Raft log, which is encrypted and replicated across manager nodes.

### 🛠️ Docker Compose Integration (Secrets)

With Compose v3.1+, you can define secrets declaratively:

```yaml
version: '3.1'
services:
  web:
    image: nginx
    secrets:
      - site_cert
secrets:
  site_cert:
    file: ./certs/site.crt
```

Secrets are mounted as files inside the container, and you can customize the target path and permissions.

### 🧪 Best Practices for Secrets

- Never hardcode secrets in Dockerfiles or source code
- Use external secret managers (e.g., HashiCorp Vault, AWS Secrets Manager) for dynamic secrets
- Rotate secrets regularly: `docker secret rm` and `docker secret create` with versioned names
- Scan images for exposed secrets using tools like GitGuardian CLI or Trivy

### 🧭 Advanced Patterns for Secrets

- **Sidecar containers:** Use a Vault sidecar to inject secrets into your main app container via shared volumes
- **Environment-based secrets:** Use the same secret name across dev, test, and prod — containers stay agnostic
- **Custom mount targets:** Map secrets to expected config paths (e.g., `/etc/nginx/conf.d/site.conf`)

---

## 🌐 What Is Docker Networking?

Docker networking enables communication between containers, the host system, and the outside world. It’s essential for microservices, service discovery, and secure inter-container traffic.

- Containers get their own network namespace: IP address, routing table, firewall rules.
- Docker uses network drivers to abstract and manage connectivity.
- You can create custom networks to isolate or group services.

### 🧱 Built-in Network Drivers

| Driver   | Description                                                        |
| -------- | ------------------------------------------------------------------ |
| bridge   | Default for standalone containers; isolates containers on a virtual subnet |
| host     | Shares host’s network stack; no isolation (Linux only)             |
| none     | No networking; container has only loopback                         |
| overlay  | Enables multi-host communication (Swarm mode)                      |
| macvlan  | Assigns MAC address; container appears as physical device on LAN   |
| ipvlan   | Similar to macvlan but uses host MAC; better for high-density setups|

### 🛠️ Creating & Managing Networks

```sh
# Create a custom bridge network
docker network create --driver bridge my-net

# Run a container in that network
docker run -d --name web --network my-net nginx

# Inspect network details
docker network inspect my-net
```

You can also connect containers to multiple networks for layered access control.

### 📡 DNS & Service Discovery

- Containers on the same user-defined bridge can resolve each other by name.
- Docker provides an embedded DNS server for custom networks.
- This enables service discovery without hardcoding IPs.

**Example:**

```sh
docker run -d --name db --network my-net postgres
docker run -d --name app --network my-net my-app
# app can reach db via hostname 'db'
```

### 🔐 Security & Isolation

- Use custom networks to isolate services (e.g., frontend vs backend).
- Avoid exposing ports unless necessary (`-p` flag).
- Use internal networks for backend-only communication:

  ```sh
  docker network create --internal backend-net
  ```

### 🚀 Advanced Patterns

- Overlay networks for multi-host setups (Swarm or Kubernetes).
- macvlan for legacy systems needing Layer 2 access.
- Sidecar containers for proxies, logging, or secrets injection.
- Network aliases for flexible naming:

  ```sh
  docker network connect --alias db-alias my-net app
  ```

---

## 📡 External Access: Host ↔ Container ↔ Internet

### 🔓 Exposing Ports

To make a container accessible from outside (e.g., browser or API client), you publish ports:

```sh
docker run -p 8080:80 nginx
```

- `-p 8080:80`: Maps port 80 inside the container to port 8080 on the host.
- Access via `http://localhost:8080` or `http://<host-ip>:8080`.

### 🌐 Internet Access from Containers

Containers can reach the internet by default using the host’s network stack. For example, a container can curl external APIs unless restricted.

### 🔒 Restricting External Access

Use `--internal` flag when creating a network to block outbound traffic:

```sh
docker network create --internal isolated-net
```

Only containers on that network can talk to each other — no internet access.

---

## 🔄 Internal Communication: Container ↔ Container

### 🧭 Shared Networks

Containers on the same user-defined bridge network can resolve each other by name:

```sh
docker network create my-net
docker run --network my-net --name db postgres
docker run --network my-net --name app my-app
```

- app can reach db via `http://db:5432`.

### 🧠 DNS Resolution

Docker provides an embedded DNS server for name-based service discovery within custom networks.

### 🧱 Compose Example

```yaml
services:
  app:
    image: my-app
    networks:
      - backend
  db:
    image: postgres
    networks:
      - backend

networks:
  backend:
```

No need to expose ports unless you want host access.

---

## 🧪 Accessing a Running Container

### 🔧 Shell Access

```sh
docker exec -it <container> sh
```

- Use bash if available, or sh for Alpine-based images.

### 📺 Logs & Attach

```sh
docker logs <container>
docker attach <container>
```

- `attach` connects to the container’s main process.
- Use CTRL-p CTRL-q to detach without stopping.

### 🔐 Security Tips

- Avoid exposing ports unless necessary.
- Use internal networks for backend-only services.
- Scan containers for vulnerabilities.
- Use firewalls or iptables to restrict traffic.

---

## 🌐 What Is host.docker.internal?

It’s a special DNS name that Docker provides to containers, allowing them to resolve the host machine’s internal IP address. This is incredibly useful when a container needs to access a service running directly on the host — like a local database, API, or dev server.

- Example: If your host runs a service on port 3000, a container can reach it via `http://host.docker.internal:3000`. This works out of the box on Docker Desktop for Windows and macOS, but requires extra setup on Linux.

### 🧭 Platform Behavior

| Platform        | Support Status         | Notes                                 |
| --------------- | --------------------- | ------------------------------------- |
| Windows/macOS   | ✅ Built-in with Docker Desktop | Works out of the box          |
| Linux (Docker Engine) | ⚠️ Requires manual setup | Use `--add-host=host.docker.internal:host-gateway` during docker run |
| WSL2            | ✅ Supported via Docker Desktop | Behaves like macOS/Windows    |

On Linux, you can also use the default bridge IP `172.17.0.1` as a workaround, but it’s less portable and can vary depending on the network setup.

### 🛠️ How to Enable on Linux

To make host.docker.internal work on Linux:

```sh
docker run --add-host=host.docker.internal:host-gateway my-container
```

Or in Docker Compose:

```yaml
services:
  app:
    image: my-app
    extra_hosts:
      - "host.docker.internal:host-gateway"
```

This maps the special DNS name to the host’s gateway IP, making it accessible inside the container.

### 🔐 Best Practices

- Use host.docker.internal for local dev only — it’s not suitable for production.
- Prefer environment variables to inject host URLs into containers.
- Avoid hardcoding IPs — DNS names are more portable and maintainable.

---

## 🌱 What Are Environment Variables?

Environment variables are key-value pairs injected into a container’s runtime environment. They’re used to configure behavior without modifying the image or source code.

- **Examples:** DB_HOST, API_KEY, NODE_ENV, PORT
- **Use Cases:** Database credentials, feature flags, service endpoints, runtime modes

### 🛠️ Ways to Set Environment Variables

1. **Dockerfile**

   ```dockerfile
   ENV NODE_ENV=production
   ```

   - Available during build and runtime
   - Can be overridden at runtime

2. **docker run**

   ```sh
   docker run -e NODE_ENV=development my-app
   ```

   - `-e` sets variables at runtime
   - Can also pull from host shell:

     ```sh
     export DB_HOST=localhost
     docker run -e DB_HOST my-app
     ```

3. **--env-file**

   ```sh
   docker run --env-file ./config.env my-app
   ```

   - File format: KEY=value per line
   - Keeps secrets out of CLI history

4. **Docker Compose**

   ```yaml
   services:
     app:
       image: my-app
       environment:
         - NODE_ENV=production
         - DB_HOST=${DB_HOST}
       env_file:
         - .env
   ```

   - Supports interpolation from .env files
   - Keeps config clean and versionable

### 🔐 Security Best Practices

- Avoid hardcoding secrets in Dockerfiles or Compose files
- Use .env files and gitignore them
- For sensitive data, prefer Docker secrets, Vault, or cloud-native secret managers
- Scan images for exposed secrets using tools like Trivy or GitGuardian

### 🧪 Inspecting Environment Variables

- Inside container:

  ```sh
  docker exec -it my-app env
  ```

- From host:

  ```sh
  docker inspect my-app
  ```

### 🧭 ENV vs ARG

| Feature   | ENV                        | ARG                       |
| --------- | -------------------------- | ------------------------- |
| Scope     | Available at build/runtime | Build-time only           |
| Visibility| Visible inside containers  | Not accessible after build|
| Use Case  | Runtime config             | Build parameters (e.g., base image) |

---

## 🧱 What Is ARG in Docker?

ARG defines a build-time variable that can be passed into the Dockerfile during the image build process. It’s not available at runtime — meaning containers created from the image won’t see it.

- **Use Case:** Customize builds (e.g., base image version, feature toggles, build flags)
- **Scope:** Available only during docker build, not during docker run

### 🛠️ Syntax & Usage

```dockerfile
ARG NODE_VERSION=18-alpine
FROM node:${NODE_VERSION}
```

You can override NODE_VERSION during build:

```sh
docker build --build-arg NODE_VERSION=20-alpine -t my-app .
```

### 🧪 Example with ARG + ENV

```dockerfile
ARG APP_PORT=3000
ENV PORT=$APP_PORT
```

- ARG is used during build
- ENV persists into the container runtime

This pattern lets you bridge build-time and runtime config.

### 🔄 ARG vs ENV

| Feature   | ARG              | ENV                |
| --------- | ---------------- | ------------------ |
| Scope     | Build-time only  | Build + runtime    |
| Visibility| Not visible in running containers | Visible inside containers |
| Use Case  | Base image version, build flags | App config, secrets, runtime setup |

### 🧠 Best Practices

- Use ARG for things like:
  - Base image versions
  - Build flags (e.g., DEBUG=true)
  - Conditional installs (e.g., dev vs prod dependencies)
- Combine with ENV if you need runtime access
- Avoid using ARG for secrets — they’re visible in image history

---

## 🏷️ What Is a Docker Tag?

A Docker tag is a label attached to a Docker image that helps identify its version, purpose, or environment. It’s the part after the colon in an image name:

```sh
nginx:1.25.2
```

- nginx: Image name
- 1.25.2: Tag (version)

If no tag is specified, Docker defaults to `latest` — but that’s just a convention, not a guarantee of freshness.

### 🧱 Anatomy of a Docker Image Reference

```text
<registry>/<namespace>/<repository>:<tag>
```

**Example:**

```sh
docker.io/library/nginx:1.25.2
```

| Component | Description                                 |
| --------- | ------------------------------------------- |
| Registry  | Where the image is stored (e.g., Docker Hub)|
| Namespace | User or org name (e.g., library, sergii)    |
| Repository| Image name (e.g., nginx)                    |
| Tag       | Version or variant (e.g., 1.25.2, prod)     |

### 🛠️ Creating & Managing Tags

- Tag an image manually:

  ```sh
  docker tag myapp:latest myapp:v1.0.0
  ```

- Build with a tag:

  ```sh
  docker build -t myapp:v1.0.0 .
  ```

- Push to registry:

  ```sh
  docker push myapp:v1.0.0
  ```

You can assign multiple tags to the same image ID — useful for semantic versioning (v1, v1.0, v1.0.0) or environment labels (dev, prod).

### ⚠️ The “latest” Tag Trap

- `latest` is not automatically updated — it just refers to the most recently pushed image without a tag.
- It’s risky in production because it can lead to unpredictable deployments.
- Prefer explicit version tags like 1.0.3 or stable.

### 🧪 Best Practices for Tagging

- Use semantic versioning: 1.0.0, 1.0.1, 2.0.0
- Apply multiple tags for flexibility:

  ```sh
  docker tag myapp:1.0.0 myapp:stable
  ```

- Avoid `latest` in production
- Automate tagging in CI/CD using commit hashes or build numbers:

  ```sh
  docker tag myapp:latest myapp:build-$(git rev-parse --short HEAD)
  ```

### 🧠 Bonus: Labels vs Tags

- **Tags:** External identifiers for image versions
- **Labels:** Internal metadata (e.g., author, version, source)

  ```dockerfile
  LABEL version="1.0.0" maintainer="sergii@example.com"
  ```

- Use `docker inspect` to view labels.

---

## 📄 What Is a Dockerfile?

A Dockerfile is a text-based script that defines how to build a Docker image. Each instruction in the file creates a layer, contributing to the final image.

- Think of it as infrastructure-as-code for container environments.
- It’s declarative: you describe what you want, and Docker builds it.

### 🧱 Core Instructions

| Instruction | Purpose                                         |
| ----------- | ----------------------------------------------- |
| FROM        | Specifies the base image (e.g., ubuntu, node:18-alpine) |
| RUN         | Executes commands during build (e.g., install packages) |
| COPY        | Copies files from host to image                 |
| ADD         | Like COPY, but supports remote URLs and auto-extracts archives |
| CMD         | Default command when container starts           |
| ENTRYPOINT  | Sets the executable for the container           |
| ENV         | Sets environment variables                      |
| EXPOSE      | Documents the port the container listens on     |
| WORKDIR     | Sets working directory inside the image         |
| USER        | Specifies the user to run commands              |
| VOLUME      | Declares mount points for persistent storage    |

### 🛠️ Example Dockerfile

```dockerfile
FROM node:18-alpine
WORKDIR /app
COPY package*.json ./
RUN npm install --production
COPY . .
EXPOSE 3000
CMD ["node", "server.js"]
```

Each instruction creates a layer, which helps with caching and efficient builds.

### 🧪 Build & Run

```sh
docker build -t my-app .
docker run -d -p 3000:3000 my-app
```

### 🧠 Best Practices

- Use multi-stage builds to reduce image size:

  ```dockerfile
  FROM node:18-alpine AS builder
  WORKDIR /app
  COPY . .
  RUN npm install && npm run build

  FROM nginx:alpine
  COPY --from=builder /app/dist /usr/share/nginx/html
  ```

- Minimize layers: Combine commands with `&&` to reduce image bloat.
- Use `.dockerignore` to exclude unnecessary files (e.g., node_modules, .git).
- Pin versions for reproducibility.
- Run as non-root for security.

### 🔐 Security Tips

- Use minimal base images (alpine, distroless).
- Scan images with Trivy, Docker Scout, or Snyk.
- Avoid secrets in Dockerfiles — use env vars or secret managers.

---

## 🧭 CMD vs ENTRYPOINT: Core Distinction

| Feature      | CMD                                 | ENTRYPOINT                        |
| ------------ | ----------------------------------- | --------------------------------- |
| Purpose      | Sets default arguments or command   | Sets fixed executable for the container |
| Overridable  | ✅ Easily overridden via docker run  | ⚠️ Only overridden with --entrypoint flag |
| Flexibility  | Great for general-purpose containers| Ideal for containers acting like executables |
| Combination  | Can be used with ENTRYPOINT to pass arguments | Receives arguments from CMD or docker run |

### 🛠️ How They Work Together

You can use both in a Dockerfile:

```dockerfile
ENTRYPOINT ["ping"]
CMD ["localhost"]
```

- Running `docker run my-image` → executes `ping localhost`
- Running `docker run my-image google.com` → executes `ping google.com`

Here, CMD provides default arguments to ENTRYPOINT. If you override the CMD at runtime, it replaces `localhost` with your argument.

### 🧪 Practical Use Cases

- Use CMD alone when you want a default command that users can easily override.
- Use ENTRYPOINT alone when your container is designed to run a specific binary (e.g., nginx, redis).
- Use both when you want a fixed executable with flexible arguments.

---

## 🔐 Exec vs Shell Form

Both support two forms:

- **Exec form (recommended):**

  ```dockerfile
  ENTRYPOINT ["nginx"]
  CMD ["-g", "daemon off;"]
  ```

- **Shell form (less predictable):**

  ```dockerfile
  ENTRYPOINT nginx
  CMD -g 'daemon off;'
  ```

Exec form avoids shell interpretation issues and ensures proper signal handling (important for PID 1 behavior).

### 🧭 Shell vs Exec Form in Dockerfile

| Form  | Behavior                                                      |
| ----- | ------------------------------------------------------------- |
| Shell | Runs the command in a shell (`/bin/sh -c`), enabling shell features |
| Exec  | Runs the command directly as a binary, bypassing the shell    |

### 🛠️ Syntax Comparison

- **Shell form:**

  ```dockerfile
  CMD echo $HOME
  ENTRYPOINT node app.js
  ```

  - Uses shell features like variable expansion, piping, chaining (&&, ||)
  - PID 1 is the shell, not the actual app

- **Exec form:**

  ```dockerfile
  CMD ["echo", "$HOME"]
  ENTRYPOINT ["node", "app.js"]
  ```

  - No shell interpretation — runs the binary directly
  - Better signal handling (e.g., SIGINT, SIGTERM)
  - Recommended for ENTRYPOINT and CMD in production

### 🧪 Practical Implications

| Feature             | Shell Form         | Exec Form         |
| ------------------- | ----------------- | ----------------- |
| Signal forwarding   | ❌ Often blocked   | ✅ Signals reach app directly |
| Variable substitution | ✅ Shell env vars ($HOME) | ❌ Unless passed via ENV or sh -c |
| Shell features      | ✅ Piping, redirection, chaining | ❌ Must invoke shell manually |
| Portability         | ❌ Requires shell in base image | ✅ Works even in minimal images |

### 🔐 Best Practices

- Use shell form for RUN when chaining commands or using shell features:

  ```dockerfile
  RUN apt-get update && apt-get install -y curl
  ```

- Use exec form for ENTRYPOINT and CMD to ensure proper signal handling:

  ```dockerfile
  ENTRYPOINT ["nginx"]
  CMD ["-g", "daemon off;"]
  ```

- If you need shell features in CMD or ENTRYPOINT, wrap them:

  ```dockerfile
  CMD ["sh", "-c", "echo $HOME && sleep 5"]
  ```

---

## 🧱 What Is a Multi-Stage Build?

A multi-stage build allows you to use multiple FROM statements in a single Dockerfile. Each FROM starts a new stage, and you can selectively copy artifacts from one stage to another.

- **Purpose:** Separate build-time dependencies (e.g., compilers, linters) from runtime artifacts.
- **Result:** Smaller, cleaner images with only what’s needed in production.

### 🛠️ Basic Example

```dockerfile
# Stage 1: Build
FROM node:18-alpine AS builder
WORKDIR /app
COPY . .
RUN npm install && npm run build

# Stage 2: Runtime
FROM nginx:alpine
COPY --from=builder /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
```

- The first stage compiles the app.
- The second stage copies only the built output — no node_modules, no build tools.

### 🧪 Benefits for You

| Advantage        | Why It Matters for Your Work         |
| ---------------- | ------------------------------------ |
| Smaller Images   | Faster deployments, lower cloud costs|
| Improved Security| Removes dev tools and reduces attack surface |
| Better CI/CD     | Clean separation of build/test/deploy stages |
| Modular Dockerfiles | Easier to maintain and extend across environments |

### 🔄 Naming & Targeting Stages

You can name stages for clarity:

```dockerfile
FROM golang:1.21 AS build
...
FROM scratch AS final
COPY --from=build /bin/app /bin/app
```

And build up to a specific stage:

```sh
docker build --target build -t debug-image .
```

Useful for debugging or testing intermediate layers.

### 📦 External Image as a Stage

You can copy from another image entirely:

```dockerfile
COPY --from=nginx:latest /etc/nginx/nginx.conf /nginx.conf
```

This lets you reuse trusted artifacts without bloating your build.

---

## 🧱 What Is Docker Compose?

Docker Compose is a tool for defining and running multi-container applications using a single YAML file (`docker-compose.yml`). It abstracts away the complexity of wiring containers together manually.

- **Declarative:** You describe your app stack in YAML.
- **Portable:** Works across dev, staging, and CI environments.
- **Efficient:** One command (`docker compose up`) spins up everything.

### 📄 Anatomy of a Compose File

```yaml
version: '3.8'

services:
  web:
    image: nginx:latest
    ports:
      - "80:80"
    networks:
      - frontend
    volumes:
      - shared-data:/usr/share/nginx/html

  app:
    build: ./app
    depends_on:
      - db
    networks:
      - frontend
      - backend
    environment:
      - DB_HOST=db

  db:
    image: postgres:15
    volumes:
      - db-data:/var/lib/postgresql/data
    networks:
      - backend

networks:
  frontend:
  backend:

volumes:
  shared-data:
  db-data:
```

### 🧪 Key Concepts

| Concept      | Purpose                                         |
| ------------ | ----------------------------------------------- |
| services     | Define each containerized component (e.g., web, db, API) |
| networks     | Enable secure inter-container communication     |
| volumes      | Persist data across container restarts          |
| depends_on   | Control startup order (can be enhanced with healthchecks) |
| environment  | Inject runtime config via env vars              |

### 🚀 Dev & CI/CD Benefits

- Local parity: Same stack runs locally and in CI.
- Fast onboarding: New devs run `docker compose up` and get the full app.
- Test isolation: Spin up ephemeral services for integration tests.
- Debug profiles: Add Prometheus, Grafana, or OpenTelemetry sidecars for local observability.

### 🔐 Security & Secrets

- Use .env files for non-sensitive config.
- For secrets, integrate with Docker secrets, Vault, or cloud-native managers.
- Compose v3.1+ supports secret mounting:

```yaml
secrets:
  db_password:
    file: ./secrets/db_password.txt
```

### 🧠 Advanced Patterns

- Multi-stage builds: Optimize image size and security.
- Profiles: Enable/disable services per environment.
- External volumes/networks: Reuse across projects.
- Compose Bridge: Convert Compose files to Kubernetes manifests for production deployment.

---

## Most Common Docker Commands

### 🚀 Container Lifecycle Commands

| Command                | Purpose                                 |
| ---------------------- | --------------------------------------- |
| docker run             | Create and start a new container        |
| docker start           | Start a stopped container               |
| docker stop            | Gracefully stop a running container     |
| docker restart         | Restart a container                     |
| docker kill            | Forcefully stop a container (SIGKILL)   |
| docker rm              | Remove a stopped container              |
| docker exec            | Run a command inside a running container|
| docker logs            | View container logs                     |
| docker ps / ps -a      | List running / all containers           |
| docker attach          | Attach to a running container’s process |

### 📦 Image Management

| Command         | Purpose                                 |
| --------------- | --------------------------------------- |
| docker build    | Build an image from a Dockerfile        |
| docker pull     | Download an image from a registry       |
| docker push     | Upload an image to a registry           |
| docker images   | List local images                       |
| docker rmi      | Remove an image                         |
| docker tag      | Apply a new tag to an image             |
| docker inspect  | View detailed metadata of image/container|

### 📁 Volume & File Operations

| Command             | Purpose                                 |
| ------------------- | --------------------------------------- |
| docker volume create| Create a named volume                   |
| docker volume ls    | List volumes                            |
| docker volume inspect| View volume details                    |
| docker volume rm    | Remove a volume                         |
| docker cp           | Copy files between host and container   |

### 🌐 Networking

| Command                 | Purpose                                 |
| ----------------------- | --------------------------------------- |
| docker network create   | Create a custom network                 |
| docker network ls       | List networks                           |
| docker network inspect  | View network details                    |
| docker network connect  | Attach container to a network           |
| docker network disconnect| Detach container from a network        |

### 🧹 Cleanup & System Info

| Command                | Purpose                                 |
| ---------------------- | --------------------------------------- |
| docker system prune    | Remove unused containers, images, volumes|
| docker info            | Show Docker system-wide info            |
| docker version         | Show Docker client/server version        |

### 🧠 Compose & Orchestration

| Command                | Purpose                                 |
| ---------------------- | --------------------------------------- |
| docker compose up      | Start services defined in docker-compose.yml |
| docker compose down    | Stop and remove services                |
| docker compose logs    | View logs for all services              |
| docker compose exec    | Run command in a service container      |

---

## ⚙️ Docker Daemon Configuration (`daemon.json`)

This file controls how the Docker Engine behaves on the host.

- **Location:**
  - Linux: `/etc/docker/daemon.json`
  - Windows: `C:\Users\<user>\.docker\config.json`
  - macOS: `~/.docker/config.json`
- **Common Settings:**

  ```json
  {
    "log-level": "info",
    "storage-driver": "overlay2",
    "registry-mirrors": ["https://mirror.gcr.io"],
    "data-root": "/mnt/docker"
  }
  ```

- **Use Cases:**
  - Change default logging behavior
  - Optimize storage drivers
  - Configure proxy or registry mirrors
  - Enable debug mode for troubleshooting

- **Apply Changes:**

  ```sh
  sudo systemctl restart docker
  ```

### 📄 Docker Configs (Swarm Mode)

Docker configs are used to manage non-sensitive configuration files in Swarm services.

- **Create a config:**

  ```sh
  echo "config content" | docker config create my_config -
  ```

- **Attach to service:**

  ```sh
  docker service create --name web --config source=my_config,target=/etc/config nginx
  ```

- **Inspect configs:**

  ```sh
  docker config inspect my_config
  ```

- **Benefits:**
  - Versioned and managed separately from images
  - Mounted as read-only files inside containers
  - Ideal for config files like nginx.conf, app.yaml, etc.

---

## 🔐 How docker login Works

When you run:

```sh
docker login
```

Docker authenticates you to a registry (e.g., Docker Hub, AWS ECR, Azure ACR) using your username and password or access token. Once authenticated, Docker stores your credentials locally so you don’t have to log in every time.

### 📁 Where Credentials Are Stored

By default, Docker stores credentials in:

- Linux/macOS: `~/.docker/config.json`
- Windows: `%USERPROFILE%\.docker\config.json`

Inside this file, you’ll find an `auths` section with base64-encoded credentials unless a credential store or helper is configured.

### 🧠 Credential Stores vs Helpers

| Feature      | Credential Store                  | Credential Helper                |
| ------------ | -------------------------------- | -------------------------------- |
| Purpose      | Securely store credentials        | Handle credentials for specific registries |
| Examples     | osxkeychain, wincred, pass, secretservice | Same as above, but registry-specific |
| Config Key   | "credsStore"                     | "credHelpers"                    |
| Security     | 🔒 More secure than plain config.json | 🔒 Scoped and flexible           |

**Example config with a store:**

```json
{
  "credsStore": "osxkeychain"
}
```

**Example with helpers:**

```json
{
  "credHelpers": {
    "myregistry.example.com": "pass"
  }
}
```

### 🛠️ Secure Login Options

- **Interactive login:**

  ```sh
  docker login
  ```

- **Non-interactive (CI/CD):**

  ```sh
  echo "$DOCKER_PASSWORD" | docker login --username "$DOCKER_USERNAME" --password-stdin
  ```

- **Multiple accounts:** Use `--config` to switch between credential files:

  ```sh
  docker --config ~/.docker/user1 login registry.example.com
  ```

### 🧪 Checking Login Status

- Inspect `~/.docker/config.json` for auths entries.
- Run:

  ```sh
  docker info | grep Username
  ```

  (May not work with credential stores — use helper CLI tools if needed.)

---

## Docker User Management

Let’s break down Docker user management into two key domains: container-level user control and organization-level access management. Each plays a vital role in securing and scaling your Docker workflows.

### 🧍‍♂️ 1. User Management Inside Containers

This is about controlling which user a container runs as, and managing file permissions, security, and access.

#### 🔧 Dockerfile USER Instruction

- Specifies the default user for running commands inside the container.
- Example:

  ```dockerfile
  RUN useradd -ms /bin/bash appuser
  USER appuser
  ```

#### 🛡️ Best Practices

- Avoid running as root (UID 0) unless absolutely necessary.
- Use non-root users to reduce attack surface.
- Set UID/GID explicitly for consistency across environments:

  ```dockerfile
  USER 1001:1001
  ```

#### 📁 Volume Permissions

- Docker respects host file ownership via UID/GID.
- Ensure mounted volumes are accessible to the container user.

### 🏢 2. Docker Hub & Organization-Level User Management

This applies when you're managing teams, roles, and access to repositories in Docker Hub or Docker Business.

#### 👥 Roles & Permissions

Docker supports multiple roles:

| Role                | Capabilities                                                      |
| ------------------- | ----------------------------------------------------------------- |
| Member              | View repositories and collaborate                                 |
| Editor              | Create/edit/delete repositories, manage team access               |
| Organization Owner  | Full control over settings, billing, teams, and members           |
| Company Owner       | Admin across multiple organizations                               |

You can assign roles via the Docker Admin Console.

#### 🔐 SSO & SCIM Integration

- Use Single Sign-On (SSO) for centralized authentication.
- Use SCIM for automated provisioning and deprovisioning of users.
- Supports identity providers like Okta, Azure AD, and Entra ID.

#### 🧠 Group Mapping

- Map IdP groups to Docker teams for scalable access control.
- Automates role assignment and reduces manual errors.

### 🧪 Container vs Organization User Management

| Scope           | Container-Level                  | Organization-Level                |
| --------------- | ------------------------------- | --------------------------------- |
| Purpose         | Runtime security and file access | Repository access and team collaboration |
| Tools           | Dockerfile (USER), UID/GID      | Docker Hub, Admin Console, SSO, SCIM |
| Risks if misconfigured | Root access, permission errors | Unauthorized access, billing misuse |

---

## 🧑‍💻 Understanding Container Users: The Basics

Every container starts with a default user, usually root (UID 0) — unless specified otherwise in the Dockerfile or at runtime.

- **View active user inside a container:**

  ```sh
  docker exec my-container whoami
  ```

If the Dockerfile doesn’t set a USER, it defaults to root, which can be risky.

### 🔐 Why Running as Root Is Dangerous

Running containers as root can:

- Expose the host to privilege escalation
- Allow access to mounted volumes with broad permissions
- Increase attack surface in multi-tenant or orchestrated environments

### 🛠️ Defining Users in Dockerfile

```dockerfile
# Create a non-root user
RUN groupadd -r appgroup && useradd -r -g appgroup appuser

# Set the default user
USER appuser
```

This ensures the container runs with limited privileges, improving isolation and security.

### 📦 Volume Mount Implications

If your volume is mounted from the host (e.g., /data), and the container user doesn’t have write access:

- You’ll hit permission denied errors
- Solution: either match UID/GID, or use chown during build

  ```dockerfile
  RUN chown appuser:appgroup /data
  ```

### 🧭 Mapping UID/GID from Host to Container

To align host and container permissions:

```sh
docker run -u $(id -u):$(id -g) -v /host/data:/app/data my-image
```

This ensures the container process mirrors your host identity.

### 🧱 Alpine vs Debian: Default Users

- Alpine images often only contain root unless explicitly added.
- Debian/Ubuntu-based images typically have nobody, daemon, etc.

Be aware of base image limitations when scripting permissions or mounting volumes.

### 👮 Security Best Practices

| Practice                | Benefit                              |
| ----------------------- | ------------------------------------ |
| Run as non-root user    | Limits scope for exploitation        |
| Use read-only file systems | Prevents tampering with base layers|
| Drop capabilities       | Reduce container privileges (`--cap-drop`) |
| Use user namespaces     | Remap container UID to non-root on host |

---

## 🧪 Alternatives to Mounting

If you need Docker access inside containers but want to avoid direct socket exposure:

- Use remote Docker APIs over TCP with TLS
- Use Docker context switching (`docker context use`)
- Use Sysbox runtime for secure Docker-in-Docker without privileged mode

---

## Docker Interview Questions with Answers

1. **What is Docker, and how does it differ from a virtual machine?**  
   Docker is a platform for developing, shipping, and running applications in lightweight, portable containers. Containers package an application and its dependencies together, ensuring consistency across environments.  
   **Key Differences from Virtual Machines:**  
   - Containers share the host OS kernel, making them lightweight and faster to start.
   - VMs include a full OS, making them heavier and slower to boot.
   - Docker containers are more resource-efficient compared to VMs.

2. **What is a Docker image, and how is it different from a container?**  
   - A Docker image is a read-only template used to create containers. It contains the application code, dependencies, and runtime environment.
   - A Docker container is a running instance of an image. Containers are mutable and can have a writable layer on top of the image.

3. **What is a Dockerfile and how does it work?**  
   A Dockerfile is a script containing instructions to build a Docker image. Each line in the file represents a layer in the final image.  
   **Common Instructions:**  
   - FROM: Specifies the base image.
   - COPY / ADD: Adds files to the image.
   - RUN: Executes commands during build (e.g., install packages).
   - CMD / ENTRYPOINT: Defines the default runtime command.  
   **Using a Dockerfile:**  

   ```sh
   docker build -t myapp:1.0 .
   ```

4. **What is the difference between CMD and ENTRYPOINT?**  
   - CMD: Provides default arguments that can be overridden.
   - ENTRYPOINT: Defines the fixed executable for the container.  
   You can combine both:

   ```dockerfile
   ENTRYPOINT ["python3"]
   CMD ["app.py"]
   ```

   So `docker run myimage` runs `python3 app.py`.

5. **What is the purpose of the .dockerignore file?**  
   This file tells Docker which files/folders to exclude during `docker build`, improving performance and reducing image size.  
   **Example:**

   ``` text
   node_modules
   .git
   .env
   ```

6. **How does Docker handle networking by default?**  
   Docker containers connect via the bridge network driver by default.
   - Containers on the same bridge network can talk via IP or DNS name.
   - You can create user-defined networks to enable DNS-based service discovery.
   - To create a custom network:

     ```sh
     docker network create mynet
     ```

7. **How do you persist data in a Docker container?**  
   Use volumes:
   - Managed by Docker (`docker volume create mydata`)
   - Mounted into containers (`-v mydata:/app/data`)
   Or use bind mounts to map a host directory:

   ```sh
   -v /host/path:/container/path
   ```

8. **What happens when you run docker run?**  
   Docker performs these steps:
   - Pulls image if not available locally.
   - Creates a new container from the image.
   - Assigns a unique ID and network.
   - Starts the container process.

9. **What are multi-stage builds and why are they useful?**  
   They allow you to use multiple FROM instructions to optimize image size:

   ```dockerfile
   FROM node:18 AS builder
   RUN npm install && npm run build

   FROM nginx:alpine
   COPY --from=builder /dist /usr/share/nginx/html
   ```

   **Benefit:** Keeps only production-ready assets in the final image.

10. **What is Docker Compose and what are its key benefits?**  
    Compose defines multi-container apps in a YAML file (`docker-compose.yml`).  
    **Benefits:**
    - Declarative configuration.
    - One-click orchestration (`docker compose up`).
    - Network and volume management.

11. **What is the difference between bind mounts and volumes?**  

    | Feature      | Bind Mounts           | Docker Volumes      |
    | ------------ | --------------------- | ------------------- |
    | Path control | Exact path on host    | Abstracted by Docker|
    | Portability  | Less portable         | Highly portable     |
    | Isolation    | Host-dependent permissions | Managed by Docker |

    Use volumes for persistent data; bind mounts for local dev convenience.

12. **How are environment variables used in Docker?**  
    They configure container behavior dynamically.  
    Ways to inject:
    - CLI: `docker run -e ENV=prod`
    - Compose:

      ```yaml
      environment:
        - ENV=prod
      ```

    - .env files

13. **How can you access a running container?**  
    Use:

    ```sh
    docker exec -it <container> sh
    ```

    For Alpine-based images, use sh; for others, use bash.

14. **How does Docker manage authentication to registries?**  
    Docker stores login credentials (after `docker login`) in `~/.docker/config.json`.  
    Use credential stores or helpers for added security:

    ```json
    {
      "credsStore": "osxkeychain"
    }
    ```

15. **What are some best practices for writing Dockerfiles?**  
    - Use minimal base images (e.g., alpine)
    - Combine commands to reduce layers
    - Use multi-stage builds for clean artifacts
    - Avoid hardcoding secrets
    - Use `.dockerignore` to reduce build context

---
