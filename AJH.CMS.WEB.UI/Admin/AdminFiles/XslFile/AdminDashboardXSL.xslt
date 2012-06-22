<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:UserControl="CMS:UserControl">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <xsl:call-template name="CreateDashboard">
    </xsl:call-template>
  </xsl:template>
  <xsl:template name="CreateDashboard">
    <xsl:variable name="CurrentModuleID">
      <xsl:choose>
        <xsl:when test="count(Menus/@ModuleID)>0">
          <xsl:value-of select="Menus/@ModuleID"/>
        </xsl:when>
        <xsl:otherwise>
          0
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="CurrentItemID">
      <xsl:choose>
        <xsl:when test="count(Menus/Menu [@Id=$CurrentModuleID])>0">
          <xsl:value-of select="$CurrentModuleID"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="Menus/Menu/@Id"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <div class="Dashboard-Items">
      <ul class="Dashboard-UL">
        <xsl:apply-templates select="Menus/Menu [@Id=$CurrentItemID]/Menu">
        </xsl:apply-templates>
      </ul>
    </div>
  </xsl:template>
  <xsl:template match="Menu">
    <li class="Dashboard-LI">
      <a href="{UserControl:ResolveUrl(@Url)}?ModuleID={@ParentID}">
        <img src="{UserControl:ResolveUrl(@Image)}" alt="{@Name}">
        </img>
        <xsl:value-of select="@Name"/>
      </a>
    </li>
  </xsl:template>
</xsl:stylesheet>