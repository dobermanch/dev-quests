🔧 Distributed Systems & Architecture
1. What is the CAP theorem, and how does it apply to system design?
CAP stands for Consistency, Availability, and Partition Tolerance. In distributed systems:
- Consistency: All nodes see the same data at the same time.
- Availability: Every request receives a response.
- Partition Tolerance: The system continues to operate despite network failures.
You can only fully achieve two of the three. For example, in Kafka, partition tolerance is a must, so you often trade between consistency and availability.

1. How would you design a system for high availability and fault tolerance?
- Use redundant components (multi-zone, multi-region).
- Implement health checks, failover, and replication.
- Use load balancing (e.g., ALB, NGINX).
- Apply retry logic, circuit breakers, and backoff strategies in services.
- Monitor with Prometheus/Grafana to detect failures early.

1. How does event-driven architecture scale better than request-response?
Event-driven systems are loosely coupled:
- Services publish events; others subscribe and react.
- Use of Kafka or Azure Event Hubs allows for async processing, horizontal scaling, and resilience during load spikes.

1. What are idempotent operations and why are they crucial in distributed systems?
Idempotent operations can be repeated without changing the result. They’re vital to ensure:
- Safe retries in case of timeouts or errors.
- Consistent state across microservices and APIs.

1. How would you mitigate distributed system failures?
- Use timeouts, retries, and bulkheads.
- Add chaos testing (e.g., Chaos Monkey).
- Apply observability through structured logging and metrics.
- Design services with graceful degradation paths.

☁️ Cloud Architecture & DevOps
6. What are best practices for cloud cost optimization?
- Use autoscaling, spot instances, and reserved capacity.
- Right-size VMs and containers.
- Archive unused storage and enable lifecycle policies.
- Monitor with cost dashboards (e.g., AWS Cost Explorer).

7. How would you plan a cloud migration for a legacy application?
- Assess readiness via 6R model (Rehost, Refactor…).
- Use phased migration: data > app > services.
- Set up CI/CD pipelines for new cloud builds.
- Monitor performance post-migration and optimize.

8. How do you secure cloud-native applications?
- Use IAM roles and least privilege access.
- Apply encryption at rest and in transit.
- Use managed secrets (e.g., AWS Secrets Manager).
- Implement WAFs, DDoS protection, and audit logs.

9. Difference between service mesh and API gateway?
- API Gateway: Ingress control, authentication, rate limiting.
- Service Mesh (e.g., Istio): Internal service-to-service traffic management, observability, retries, mTLS.
They complement each other in microservice architectures.

10. What’s your approach to designing scalable APIs?
- Versioning (/v1/products)
- Pagination and filtering
- Cacheable responses (using ETag)
- Use of OpenAPI for documentation
- Async pattern for long-running jobs via Webhooks or event queues

🐳 Docker & Kubernetes
11. What are Kubernetes RBAC best practices?
- Use ServiceAccounts and scoped roles.
- Follow least privilege: no wildcards unless necessary.
- Separate dev/test/prod permissions.
- Audit and rotate RBAC policies regularly.

12. How do you manage secrets securely in Kubernetes?
- Use Secrets with encryptionProviders (e.g., KMS)
- Avoid exposing secrets via env
- Consider external stores like Vault
- Use namespaces and RBAC to scope access

13. What’s the difference between ConfigMaps and Secrets?
- ConfigMaps: Non-sensitive config (e.g., app flags)
- Secrets: Base64-encoded sensitive data Both can be mounted as files or injected via env.

14. What’s a sidecar container and when do you use it?
Runs alongside a main container to:
- Log, monitor, or proxy traffic (e.g., Envoy for Istio)
- Inject secrets or configs dynamically
- Extend functionality without modifying app code

15. What are key strategies for multi-cluster Kubernetes?
- Centralized observability and logging
- Federation for global policies
- Network connectivity via VPN or service mesh
- Shared container registry and CI/CD with cluster targeting

🔐 Security & Configuration
16. How do you manage TLS certificates across services?
- Use ACME protocol via cert-manager on K8s
- Automate renewals and monitoring
- Store certs securely in volumes or secret managers
- Offload TLS to ingress controller if appropriate

17. What’s your approach to dependency vulnerability management?
- Use tools like Trivy, Snyk, or Docker Scout
- Shift-left via CI scans
- Set up alerts for newly discovered CVEs
- Rotate builds and base images proactively

18. What’s a supply chain attack, and how do you defend against it?
An attacker compromises dependencies or build tools. Defense includes:
- SBOMs (Software Bill of Materials)
- Signed images (Notary/Venafi)
- CI pipeline isolation
- Runtime verification via policies (e.g., OPA, Kyverno)

19. How do you enforce secure configurations in CI/CD?
- Use Git hooks, pre-commit checks for secrets
- Scan Dockerfiles for root access or excessive layers
- Enforce linting and security benchmarks (CIS, OWASP)

20. What tools or patterns do you use for config drift detection?
- Terraform with state comparison
- ArgoCD/Kustomize drift detection
- Use CI to reconcile desired vs actual state
- Alerting for unauthorized config changes

🔄 CI/CD, Observability & Troubleshooting
21. What’s your CI/CD pipeline structure for multi-service deployments?
- Build: Docker + image tagging
- Test: Unit, integration, security scans
- Deploy: Helm charts or kubectl via GitOps
- Promote across environments (dev → staging → prod)
- Use feature flags for dynamic rollouts

22. How do you ensure fast and safe rollbacks?
- Versioned deployments with Helm or manifests
- Use blue/green or canary deployment strategies
- Monitor metrics for regressions
- Automate rollbacks with alerts or failure gates

23. How do you design for observability?
- Structured logging (e.g., JSON logs)
- Trace propagation via OpenTelemetry
- Metrics collection via Prometheus + Grafana
- Real-time dashboards, alerts, and anomaly detection

24. What’s your approach to log aggregation?
- Use FluentBit/Fluentd with Elasticsearch, Loki, or Splunk
- Tail logs for specific containers via kubectl logs
- Use log retention policies and filters
- Normalize log formats across services

25. How do you troubleshoot inter-service latency?
- Use distributed tracing tools (e.g., Jaeger)
- Check ingress/egress times, DNS resolution, and retries
- Use netstat, curl, tcpdump as needed
- Visualize span bottlenecks in tracing dashboard

💬 Leadership, Collaboration & Strategy
26. How do you communicate complex architecture decisions to non-technical stakeholders?
- Use visuals and analogies (e.g., system diagrams)
- Frame decisions in terms of business outcomes (cost, reliability, time-to-market)
- Provide options with trade-offs
- Align with organizational OKRs

27. How do you mentor junior engineers on cloud and architecture?
- Pair programming or design reviews
- Create reusable templates and documentation
- Introduce them to sandbox environments
- Encourage learning via hands-on challenges

28. How do you prioritize tech debt vs feature development?
- Categorize debt by impact and urgency
- Embed debt fixes into sprints
- Show quantifiable cost (e.g., error rate, build time)
- Align with stakeholders on acceptable trade-offs

29. Describe a time you introduced a major system improvement.
(Use STAR format.)
- Situation: Legacy service with scaling issues
- Task: Migrate to microservices on Kubernetes
- Action: Designed new architecture, CI/CD, metrics
- Result: 50% faster deployments, 99.99% uptime, 35% lower cloud spend

30. What are the key qualities of a good Software Architect?
- Strategic thinking + practical execution
- Ability to make trade-offs visible
- Deep technical mastery + collaborative leadership
