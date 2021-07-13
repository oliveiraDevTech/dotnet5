﻿// <auto-generated />
using System;
using Infrastructure.Data.Context.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CadastroContext))]
    partial class CadastroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Cadastro.EmpresaAgreggate.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Nome");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("RazaoSocial");

                    b.Property<int>("Tipo")
                        .HasMaxLength(14)
                        .HasColumnType("int")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Empresas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Empresa");
                });

            modelBuilder.Entity("Domain.Cadastro.EnderecoAggregate.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Domain.Cadastro.EstoqueAgreggate.Estoque", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Fabricacao")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FornecedorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("Domain.Cadastro.EstoqueAgreggate.MovimentoEstoque", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("EstoqueId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Lancamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tipo")
                        .HasMaxLength(14)
                        .HasColumnType("int")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("Estoques_Movimentos");
                });

            modelBuilder.Entity("Domain.Cadastro.FornecedorAgreggate.Fornecedor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("EmpresaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Domain.Cadastro.ProdutoAggregate.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long?>("FornecedorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Tipo")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Domain.Cadastro.EmpresaAgreggate.Filial", b =>
                {
                    b.HasBaseType("Domain.Cadastro.EmpresaAgreggate.Empresa");

                    b.Property<long?>("MatrizId")
                        .HasColumnType("bigint");

                    b.HasIndex("MatrizId");

                    b.HasDiscriminator().HasValue("Filial");
                });

            modelBuilder.Entity("Domain.Cadastro.EmpresaAgreggate.Empresa", b =>
                {
                    b.HasOne("Domain.Cadastro.EnderecoAggregate.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.OwnsOne("Domain.Cadastro.EmpresaAgreggate.ValueObjects.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<long>("EmpresaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .UseIdentityColumn();

                            b1.Property<string>("Codigo")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)")
                                .HasColumnName("Cnpj");

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresas");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });

                    b.Navigation("Cnpj");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Domain.Cadastro.EstoqueAgreggate.Estoque", b =>
                {
                    b.HasOne("Domain.Cadastro.FornecedorAgreggate.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.HasOne("Domain.Cadastro.ProdutoAggregate.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.OwnsOne("Domain.Cadastro.EstoqueAgreggate.ValueObjects.Quantidade", "Quantidade", b1 =>
                        {
                            b1.Property<long>("EstoqueId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .UseIdentityColumn();

                            b1.Property<int>("Unidade")
                                .HasColumnType("int");

                            b1.Property<double>("Valor")
                                .HasColumnType("float")
                                .HasColumnName("Quantidade");

                            b1.HasKey("EstoqueId");

                            b1.ToTable("Estoques");

                            b1.WithOwner()
                                .HasForeignKey("EstoqueId");
                        });

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");

                    b.Navigation("Quantidade");
                });

            modelBuilder.Entity("Domain.Cadastro.EstoqueAgreggate.MovimentoEstoque", b =>
                {
                    b.HasOne("Domain.Cadastro.EstoqueAgreggate.Estoque", null)
                        .WithMany("Movimentos")
                        .HasForeignKey("EstoqueId");
                });

            modelBuilder.Entity("Domain.Cadastro.FornecedorAgreggate.Fornecedor", b =>
                {
                    b.HasOne("Domain.Cadastro.EmpresaAgreggate.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Cadastro.ProdutoAggregate.Produto", b =>
                {
                    b.HasOne("Domain.Cadastro.FornecedorAgreggate.Fornecedor", null)
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId");

                    b.OwnsOne("Domain.Cadastro.ProdutoAggregate.ValueObject.Medida", "Medida", b1 =>
                        {
                            b1.Property<long>("ProdutoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .UseIdentityColumn();

                            b1.Property<decimal>("Altura")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("Comprimento")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("Largura")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.OwnsOne("Domain.Cadastro.ProdutoAggregate.ValueObject.Peso", "Peso", b1 =>
                        {
                            b1.Property<long>("ProdutoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .UseIdentityColumn();

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Peso");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");
                        });

                    b.OwnsOne("Domain.Cadastro.ProdutoAggregate.ValueObject.Preco", "Preco", b1 =>
                        {
                            b1.Property<long>("ProdutoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .UseIdentityColumn();

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Preco");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");

                            b1.OwnsOne("Domain.Cadastro.ProdutoAggregate.ValueObject.Imposto", "Imposto", b2 =>
                                {
                                    b2.Property<long>("PrecoProdutoId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint")
                                        .UseIdentityColumn();

                                    b2.Property<decimal>("Cofins")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<decimal>("Icms")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<decimal>("Ipi")
                                        .HasColumnType("decimal(18,2)");

                                    b2.Property<decimal>("Pis")
                                        .HasColumnType("decimal(18,2)");

                                    b2.HasKey("PrecoProdutoId");

                                    b2.ToTable("Produtos");

                                    b2.WithOwner()
                                        .HasForeignKey("PrecoProdutoId");
                                });

                            b1.Navigation("Imposto");
                        });

                    b.Navigation("Medida");

                    b.Navigation("Peso");

                    b.Navigation("Preco");
                });

            modelBuilder.Entity("Domain.Cadastro.EmpresaAgreggate.Filial", b =>
                {
                    b.HasOne("Domain.Cadastro.EmpresaAgreggate.Empresa", "Matriz")
                        .WithMany()
                        .HasForeignKey("MatrizId");

                    b.Navigation("Matriz");
                });

            modelBuilder.Entity("Domain.Cadastro.EstoqueAgreggate.Estoque", b =>
                {
                    b.Navigation("Movimentos");
                });

            modelBuilder.Entity("Domain.Cadastro.FornecedorAgreggate.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
